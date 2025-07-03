using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    internal class Account
    {
        public string accNumber;
        public string currency;
        public int balance;


        public Account(string accNumber, string currency, int balance)
        {
            try
            {
                if (accNumber.Length != 22)
                {
                    throw new Exception("Account number must be exactly 22 characters long. Please check and try again.");
                }
                else if (currency.Length != 3)
                {
                    throw new Exception("Currency code must be 3 letters ( USD, EUR, GEL,...). Please enter a valid currency.");
                }
                else if (balance < 0)
                {
                    throw new Exception("Balance must not be less than 0!");
                }
                else
                {
                    this.accNumber = accNumber;
                    this.currency = currency;   
                    this.balance = balance;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }

        }
    }
}
