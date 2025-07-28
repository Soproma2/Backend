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

            var top = Student.Custom_TopStudent(students, s => s.Score);
            double avg = Student.Custom_Average(students, s => s.Score);
            var grades = Student.Custom_ConvertToGrades(students, s =>
            {
                if (s.Score >= 90) return "A";
                if (s.Score >= 75) return "B";
                return "C";
            });
            Student.Custom_UpdateScores(students, s => s.Score += 5);

            Student.Custom_AddStudents(students, list =>
            {
                list.Add(new Student { Name = "Saba", Score = 82 });
                list.Add(new Student { Name = "Mariam", Score = 97 });
            });

            Student.Custom_LogStudents(students, s => Console.WriteLine($"Student: {s.Name}, Score: {s.Score}"));
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
