using HomeWork34.Services;

try
{
    StudentService studentService = new StudentService();

    while (true)
    {
        Console.WriteLine("\n===== STUDENT MANAGEMENT MENU =====");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Add Student Details");
        Console.WriteLine("3. Show Student");
        Console.WriteLine("4. Show All Students");
        Console.WriteLine("5. Exit");
        Console.Write("Choose option: ");

        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice)
        {
            case "1":
                studentService.AddStudent();
                break;

            case "2":
                studentService.AddStudentDetails();
                break;

            case "3":
                studentService.ShowStudent();
                break;

            case "4":
                studentService.ShowStudents();
                break;

            case "5":
                Console.WriteLine("Exiting program...");
                return;

            default:
                Console.WriteLine("Invalid option! Try again.");
                break;
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}catch(Exception ex)
{
    Console.WriteLine(ex.Message); 
}