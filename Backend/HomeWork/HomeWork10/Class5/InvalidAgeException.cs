using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10.Class5
{
    internal class InvalidAgeException : Exception
    {
        //შექმენი ახალი კლასი InvalidAgeException, რომელიც მემკვიდრეობით მიიღებს Exception - ს.
        //დაწერე მეთოდი RegisterUser(int age), რომელიც age< 18 შემთხვევაში აგდებს ამ გამონაკლისს.

        public InvalidAgeException() : base("Registration failed: Age must be 18 or older.") { }


        public InvalidAgeException(string message) : base(message) { }

    }
}
