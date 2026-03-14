namespace HomeWork_66__Asp___Registration.DTOs.Requests
{
    public class ResetPasswordReq
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
