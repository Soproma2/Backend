using HomeWork_66__Asp___Registration.Common;
using HomeWork_66__Asp___Registration.DTOs.Requests;
using HomeWork_66__Asp___Registration.DTOs.Responses;
using HomeWork_66__Asp___Registration.Models;
using HomeWork_66__Asp___Registration.Services.Email;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HomeWork_66__Asp___Registration.Data;

namespace HomeWork_66__Asp___Registration.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly SMTPService _emailService;

        public AuthService(AppDbContext context, IConfiguration config, SMTPService emailService)
        {
            _context = context;
            _config = config;
            _emailService = emailService;
        }

        public Result<string> Register(RegisterReq req)
        {
            if (string.IsNullOrWhiteSpace(req.UserName))
                return Result<string>.BadRequest("Username is required");

            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<string>.BadRequest("Password is required");

            if (req.Password.Length < 6)
                return Result<string>.BadRequest("Password must be at least 6 characters");

            if (_context.Users.Any(u => u.Email == req.Email))
                return Result<string>.BadRequest("Email already in use");

            if (_context.Users.Any(u => u.UserName == req.UserName))
                return Result<string>.BadRequest("Username already taken");

            var code = GenerateCode();

            var user = new User
            {
                UserName = req.UserName,
                Email = req.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
                VerificationCode = code,
                VerificationCodeExpiry = DateTime.Now.AddMinutes(15)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            _emailService.SendAsync(
                req.Email,
                "Verify your email",
                $"<h2>Your verification code: <b>{code}</b></h2><p>Expires in 15 minutes.</p>"
            );

            return Result<string>.success("Registration successful. Please verify your email.", null);
        }

        public Result<string> Login(LoginReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<string>.BadRequest("Password is required");

            var user = _context.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user == null)
                return Result<string>.NotFound("Invalid email or password");

            if (!BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
                return Result<string>.BadRequest("Invalid email or password");

            if (!user.IsEmailConfirmed)
                return Result<string>.BadRequest("Please verify your email first");

            return Result<string>.success("Login successful", GenerateToken(user));
        }

        public Result<string> VerifyEmail(VerifyEmailReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Code))
                return Result<string>.BadRequest("Email and code are required");

            var user = _context.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user == null)
                return Result<string>.NotFound("User not found");

            if (user.IsEmailConfirmed)
                return Result<string>.BadRequest("Email already verified");

            if (user.VerificationCode != req.Code)
                return Result<string>.BadRequest("Invalid verification code");

            if (user.VerificationCodeExpiry < DateTime.Now)
                return Result<string>.BadRequest("Verification code has expired");

            user.IsEmailConfirmed = true;
            user.VerificationCode = null;
            user.VerificationCodeExpiry = null;
            user.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return Result<string>.success("Email verified successfully", GenerateToken(user));
        }

        public Result<string> ForgotPassword(ForgotPasswordReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            var user = _context.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user == null)
                return Result<string>.NotFound("User not found");

            if (!user.IsEmailConfirmed)
                return Result<string>.BadRequest("Email is not verified");

            var code = GenerateCode();

            user.ResetPasswordCode = code;
            user.ResetPasswordCodeExpiry = DateTime.Now.AddMinutes(15);
            user.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            _emailService.SendAsync(
                req.Email,
                "Reset your password",
                $"<h2>Your reset code: <b>{code}</b></h2><p>Expires in 15 minutes.</p>"
            );

            return Result<string>.success("Reset code sent to your email", null);
        }

        public Result<string> ResetPassword(ResetPasswordReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Code))
                return Result<string>.BadRequest("Code is required");

            if (string.IsNullOrWhiteSpace(req.NewPassword))
                return Result<string>.BadRequest("New password is required");

            if (req.NewPassword.Length < 6)
                return Result<string>.BadRequest("Password must be at least 6 characters");

            var user = _context.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user == null)
                return Result<string>.NotFound("User not found");

            if (user.ResetPasswordCode != req.Code)
                return Result<string>.BadRequest("Invalid reset code");

            if (user.ResetPasswordCodeExpiry < DateTime.Now)
                return Result<string>.BadRequest("Reset code has expired");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.NewPassword);
            user.ResetPasswordCode = null;
            user.ResetPasswordCodeExpiry = null;
            user.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return Result<string>.success("Password reset successfully", null);
        }

        public Result<UserResponse> GetMe(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                return Result<UserResponse>.NotFound("User not found");

            return Result<UserResponse>.success(null, new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                IsEmailConfirmed = user.IsEmailConfirmed
            });
        }

        private static string GenerateCode()
            => new Random().Next(100000, 999999).ToString();

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
