using System.Security.Cryptography.X509Certificates;

namespace HomeWork14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //მოცემულია სტუდენტების სია და მათი ქულები. უნდა შეიქმნას პროგრამა, რომელიც შესაბამისი დელეგატის გამოყენებით შეასრულებს სხვადასხვა ანალიზს, როგორიცაა:

            var students = new List<Student>
            {
                new Student { Name = "Ana", Score = 92 },
                new Student { Name = "Luka", Score = 75 },
                new Student { Name = "Nino", Score = 88 },
                new Student { Name = "Giorgi", Score = 61 },
                new Student { Name = "Tamar", Score = 99 }
            };


            var student_score = Student.point();
            var student_score1 = Student.point();
            var student_score2 = Student.point();
            var student_score3 = Student.point();
            var student_score4 = Student.point();
            var student_score5 = Student.point();
            var student_score6 = Student.point();

            //1 მაღალი ქულის მქონე სტუდენტის პოვნა
            //2 საშუალო ქულის გამოთვლა
            //3 გაცემული ქულების გარდაქმნა ახალ სკალაში(მაგ. 0–100 → A/B/C)
            //4 სტუდენტების ქულის განახლება
            //5 სიაში სტუდენტების დამატება
            //6 სტუდენტების ქულების ლოგირება


            //მინიშნება
            //გამოიყენე Func<Student, int> დელეგატი ქულების მიღებისთვის
            //გამოიყენე Func<List<Student>, double> საშუალო ქულის გამოსათვლელად
            //გამოიყენე Func<Student, string> ქულის ასოებში გადასაყვანად:
            //გამოიყენე Action<Student> დელეგატი სტუდენტის ქულის განახლებისთვის:
            //გამოიყენე Action<Student> დელეგატი სტუდენტის ქულის დაბეჭდვისთვის:
            //გამოიყენე Action<List<Student>> დელეგატი სიაში სტუდენტების დამატებისთვის:





        }
    }
}
