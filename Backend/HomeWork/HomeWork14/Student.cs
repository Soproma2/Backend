using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork14
{
    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public delegate int ScoreDelegate(Student student);
        public delegate double AverageDelegate(List<Student> students);
        public delegate string GradeDelegate(Student student);
        public delegate void UpdateScoreDelegate(Student student);
        public delegate void LogScoreDelegate(Student student);
        public delegate void AddStudentsDelegate(List<Student> students);



        public static Student Custom_TopStudent(List<Student> students, Func<Student, int> scoreSelector)
        {
            Student top = students[0];
            foreach (var student in students)
            {
                if (scoreSelector(student) > scoreSelector(top))
                {
                    top = student;
                }
            }
            return top;
        }


        public static double Custom_Average(List<Student> students, Func<Student, int> scoreSelector)
        {
            int total = 0;
            foreach (var student in students)
            {
                total += scoreSelector(student);
            }
            return (double)total / students.Count;
        }

        public static List<string> Custom_ConvertToGrades(List<Student> students, Func<Student, string> gradeConverter)
        {
            List<string> grades = new List<string>();
            foreach (var student in students)
            {
                grades.Add($"{student.Name}: {gradeConverter(student)}");
            }
            return grades;
        }

        public static void Custom_UpdateScores(List<Student> students, Action<Student> updateAction)
        {
            foreach (var student in students)
            {
                updateAction(student);
            }
        }

        public static void Custom_AddStudents(List<Student> students, Action<List<Student>> addAction)
        {
            addAction(students);
        }

        public static void Custom_LogStudents(List<Student> students, Action<Student> logAction)
        {
            foreach (var student in students)
            {
                logAction(student);
            }
        }





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
