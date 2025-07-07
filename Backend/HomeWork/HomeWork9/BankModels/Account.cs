using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9.BankModels
{
    internal class Account
    {
		private string iban;

		public string Iban
		{
			get { return iban; }
			set
			{
				if (value.Length == 22)
				{
					iban = value;
				}
			}
		}

		private string currency;

		public string Currency
		{
			get { return currency; }
			set
			{
				if(value.Length == 3)
				{
					currency = value.ToUpper();
				}
			}
		}

		private decimal balance;
		public decimal Balance
		{
			get { return balance;}
			set
			{
				if(value > 0)
				{
					balance = value;
				}
			}
		}
		
		public decimal withdraw
		{
			get { return balance; }
			set
			{
                if (balance < value)
                {
                    throw new Exception("You don't have enough money!");
                }
                balance -= value;
            }
		}

		public decimal deposit
		{
			get { return balance; }
			set
			{
                balance += value;
            }
		}


        //public decimal withdraw(decimal amount)
        //{
        //    if (balance < amount)
        //    {
        //        throw new Exception("You don't have enough money!");
        //    }
        //    balance -= amount;
        //}

        //public decimal deposit(decimal amount)
        //{
        //    balance += amount;
        //}


    }
}
