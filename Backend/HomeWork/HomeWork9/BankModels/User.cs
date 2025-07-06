using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9.BankModels
{
    internal class User
    {
        private string personalNumber;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Account Account { get; set; }
        public string PersonalNumber
        {
            get { return personalNumber; }
            set
            {
                if(value.Length == 11)
                {
                    personalNumber = value;
                }
            }
        }
    }
}
