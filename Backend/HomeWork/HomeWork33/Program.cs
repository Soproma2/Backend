using HomeWork33.Data;
using HomeWork33.Services;

DataContext _db = new DataContext();
SchoolService _ss = new SchoolService();

while (true)
{
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Add Course");
    Console.WriteLine("3. Register student course");
    Console.WriteLine("4. exit");

    string key = Console.ReadLine();

    switch (key)
    {
        case "1":
            _ss.AddStudent();
            break;
        case "2":
            _ss.AddCourse();
            break;
        case "3":
            _ss.StudentCourse();
            break;
        case "4":
            break;
    }

}
