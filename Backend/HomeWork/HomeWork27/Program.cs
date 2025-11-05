using HomeWork27.Data;
using HomeWork27.Services;

StudentService studentService = new StudentService();

while (true)
{
    Console.WriteLine("\n====== Student Management System ======");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Get Student By Id");
    Console.WriteLine("3. Get All Students");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Delete Student");
    Console.WriteLine("6. Search Students");
    Console.WriteLine("7. Deactivate Student");
    Console.WriteLine("8. Activate Student");
    Console.WriteLine("9. Get Top Student");
    Console.WriteLine("0. Exit");
    Console.WriteLine("=======================================");
    Console.Write("Choose option: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    try
    {
        switch (choice)
        {
            case "1":
                studentService.AddStudent();
                break;

            case "2":
                studentService.GetStudentById();
                break;

            case "3":
                studentService.GetAllStudents();
                break;

            case "4":
                studentService.UpdateStudent();
                break;

            case "5":
                studentService.DeleteStudent();
                break;

            case "6":
                studentService.SearchStudents();
                break;

            case "7":
                studentService.DeactivateStudent();
                break;

            case "8":
                studentService.ActivateStudent();
                break;

            case "9":
                studentService.GetTopStudents();
                break;

            case "0":
                Console.WriteLine("Exiting...");
                return;

            default:
                Console.WriteLine("Invalid option! Try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}