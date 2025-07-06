using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9
{
    internal class Student
    {
        private int age;
        private int score;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if( value >= 18 && value <= 50)
                {
                    age = value;
                }
            }

        }

        public int Score
        {
            get { return score; }
            set
            {
                if( value >=0 && value <= 100)
                {
                    score = value;
                }
            }
        }
    }
}
