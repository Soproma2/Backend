namespace ClassWork6
{
    public class Person
    {
        public string name;
        public string lastname;
        public int age;
        public string personalNumber;
        public string phoneNumber;
        public string eMail;

        public Person(string name, string lastname, int age, string personalNumber, string phoneNumber, string eMail)
        {
            this.name = name;
            this.lastname = lastname;
            this.age = age;
            this.personalNumber = personalNumber;
            this.phoneNumber = phoneNumber;
            this.eMail = eMail;
        }

        public Person()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person myObj = new Person()
            {
                name = "Nikoloz",
                lastname = "Sopromadze",
                age = 17,
                personalNumber = "12335124512353",
                phoneNumber = "5992400**",
                eMail = "stepnika4@gmail.com"
            };

            Console.WriteLine($"My name is {myObj.name}{myObj.lastname}. I am {myObj.age} years old. My personal number is {myObj.personalNumber}. My phone number is {myObj.phoneNumber}. My email is {myObj.eMail}");

            Person myObj2 = new Person("Nikoloz", "Sopromadze", 17, "2134252235123512", "5992400**", "stepnika4@gmail.com");
            Console.WriteLine($"My name is {myObj2.name}{myObj2.lastname}. I am {myObj2.age} years old. My personal number is {myObj2.personalNumber}. My phone number is {myObj2.phoneNumber}. My email is {myObj2.eMail}");
        }
    }
}
