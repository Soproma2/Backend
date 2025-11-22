using HomeWork36.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork36.Services
{
    internal class MotivationService
    {
        private readonly DataContext _db;
        private readonly SMTPService _emailService;

        public MotivationService(DataContext db, SMTPService emailService)
        {
            _db = db;
            _emailService = emailService;
        }

        public void SendMotivationToAll(string message)
        {
            var users = _db.Users.Where(u => u.IsEmailConfirmed).ToList();

            if (!users.Any())
            {
                Console.WriteLine("No verified users found to send emails.");
                return;
            }

            foreach (var user in users)
            {
                try
                {
                    _emailService.SendEmail(
                        "Motivation Email",
                        user.Email,
                        message
                    );

                    Console.WriteLine($"Email set to {user.Username} ({user.Email})");
                }catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email to {user.Email}: {ex.Message}");
                }
            }

            Console.WriteLine("All emails processed.");
        }
    }
}
