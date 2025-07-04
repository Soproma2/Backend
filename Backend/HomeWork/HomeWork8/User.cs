using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    internal class User
    {
        public string firstName;
        public string lastName;
        public string personalNumber;
        public Account account;

        public User(string firstName, string lastName, string personalNumber, Account account)
        {
            try
            {
                if (personalNumber.Length != 11)
                {
                    throw new Exception("Personal number must be exactly 3 characters long!");
                }
                else
                {
                    this.firstName = firstName;
                    this.lastName = lastName;
                    this.personalNumber = personalNumber;
                    this.account = account;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }
        }
    }
}
