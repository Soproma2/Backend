using HomeWork31.Services;

StudentService _studentService = new StudentService();
CourseService _courseService = new CourseService();

while (true)
{
    Console.WriteLine("\n--- MENU ---");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Show Students");
    Console.WriteLine("3. Show Student By Id");
    Console.WriteLine("4. Add Course");
    Console.WriteLine("5. Show Courses");
    Console.WriteLine("6. Add Course to Student");
    Console.WriteLine("7. Exit");
    Console.Write("Choose option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            _studentService.CreateStudent();
            break;

        case "2":
            _studentService.ShowStudents();
            break;

        case "3":
            _studentService.ShowStudentById();
            break;

        case "4":
            _courseService.addCourse();
            break;

        case "5":
            _courseService.courses();
            break;

        case "6":
            _courseService.addCourseStudent();
            break;

        case "7":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option! Try again.");
            break;
    }
}