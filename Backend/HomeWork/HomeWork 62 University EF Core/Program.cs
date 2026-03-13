using HomeWork_62_University_EF_Core.Data;
using HomeWork_62_University_EF_Core.Enums;
using HomeWork_62_University_EF_Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

class Program
{
    static StudentService _studentService;
    static ProfessorService _professorService;
    static FacultyService _facultyService;
    static CourseService _courseService;
    static ExamService _examService;

    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        using var context = new UniversityDbContext();
        await context.Database.EnsureCreatedAsync();

        _studentService = new StudentService(context);
        _professorService = new ProfessorService(context);
        _facultyService = new FacultyService(context);
        _courseService = new CourseService(context);
        _examService = new ExamService(context);

        await MainMenuAsync();
    }

    // ══════════════════════════════════════════════════════════════════
    //                        მთავარი მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task MainMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║      უნივერსიტეტის მართვის სისტემა      ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. სტუდენტების მართვა                  ║");
            Console.WriteLine("║  2. პროფესორების მართვა                 ║");
            Console.WriteLine("║  3. ფაკულტეტების მართვა                 ║");
            Console.WriteLine("║  4. კურსების მართვა                     ║");
            Console.WriteLine("║  5. გამოცდების მართვა                   ║");
            Console.WriteLine("║  0. გასვლა                              ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await StudentMenuAsync(); break;
                case "2": await ProfessorMenuAsync(); break;
                case "3": await FacultyMenuAsync(); break;
                case "4": await CourseMenuAsync(); break;
                case "5": await ExamMenuAsync(); break;
                case "0": Console.WriteLine("ნახვამდის!"); return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    // ══════════════════════════════════════════════════════════════════
    //                      სტუდენტების მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task StudentMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           სტუდენტების მართვა            ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. სტუდენტის დამატება                  ║");
            Console.WriteLine("║  2. ყველა სტუდენტის ნახვა               ║");
            Console.WriteLine("║  3. სტუდენტის დეტალები (ID-ით)          ║");
            Console.WriteLine("║  4. კურსზე ჩარიცხვა                     ║");
            Console.WriteLine("║  5. ნიშნის დაყენება                     ║");
            Console.WriteLine("║  6. კლუბში გაწევრიანება                 ║");
            Console.WriteLine("║  7. სტიპენდიის მინიჭება                 ║");
            Console.WriteLine("║  8. სტუდენტის წაშლა                     ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddStudentAsync(); break;
                case "2": await ListStudentsAsync(); break;
                case "3": await StudentDetailsAsync(); break;
                case "4": await EnrollStudentAsync(); break;
                case "5": await SetGradeAsync(); break;
                case "6": await JoinClubAsync(); break;
                case "7": await AwardScholarshipAsync(); break;
                case "8": await DeleteStudentAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddStudentAsync()
    {
        Console.Clear();
        Header("სტუდენტის დამატება");

        var code = Read("სტუდენტის კოდი (მაგ: STU-2024-001)");
        var email = Read("ელ-ფოსტა");
        var year = ReadInt("ჩარიცხვის წელი");
        var name = Read("სრული სახელი");
        var dob = ReadDate("დაბადების თარიღი (dd.MM.yyyy)");
        var address = Read("მისამართი");
        var phone = Read("ტელეფონი");
        var id = Read("პირადი ნომერი");

        var student = await _studentService.CreateStudentAsync(
            code, email, year, name, dob, address, phone, id);

        Success($"სტუდენტი დაემატა! ID: {student.Id}");
        Pause();
    }

    static async Task ListStudentsAsync()
    {
        Console.Clear();
        Header("ყველა სტუდენტი");

        var students = await _studentService.GetAllStudentsAsync();
        if (students.Count == 0) { Info("სტუდენტი არ მოიძებნა."); Pause(); return; }

        Console.WriteLine($"  {"ID",-5} {"კოდი",-15} {"სახელი",-25} {"წელი",-6}");
        Console.WriteLine(new string('─', 55));
        foreach (var s in students)
            Console.WriteLine($"  {s.Id,-5} {s.StudentCode,-15} {s.StudentProfile?.FullName,-25} {s.EnrollmentYear,-6}");

        Pause();
    }

    static async Task StudentDetailsAsync()
    {
        Console.Clear();
        Header("სტუდენტის დეტალები");

        var id = ReadInt("სტუდენტის ID");
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null) { Error("სტუდენტი ვერ მოიძებნა."); Pause(); return; }

        Console.WriteLine($"\n  👤 {student.StudentProfile?.FullName}  ({student.StudentCode})");
        Console.WriteLine($"  📧 {student.Email}  |  ჩარიცხვა: {student.EnrollmentYear}");

        Console.WriteLine("\n  📚 კურსები:");
        if (student.Enrollments.Count == 0) Console.WriteLine("     —");
        foreach (var e in student.Enrollments)
            Console.WriteLine($"     ▸ {e.Course?.CourseName}  |  ნიში: {(e.Grade.HasValue ? e.Grade.ToString() : "—")}  |  {e.Status}");

        Console.WriteLine("\n  🎯 კლუბები:");
        if (student.StudentClubs.Count == 0) Console.WriteLine("     —");
        foreach (var sc in student.StudentClubs)
            Console.WriteLine($"     ▸ {sc.Club?.Name}  [{sc.Position}]");

        Console.WriteLine("\n  🏆 სტიპენდიები:");
        if (student.StudentScholarships.Count == 0) Console.WriteLine("     —");
        foreach (var ss in student.StudentScholarships)
            Console.WriteLine($"     ▸ {ss.Scholarship?.Name}  —  {ss.Scholarship?.Amount}₾  |  აქტიური: {ss.IsActive}");

        Pause();
    }

    static async Task EnrollStudentAsync()
    {
        Console.Clear();
        Header("კურსზე ჩარიცხვა");

        var studentId = ReadInt("სტუდენტის ID");
        var courseId = ReadInt("კურსის ID");

        try
        {
            await _studentService.EnrollStudentAsync(studentId, courseId);
            Success("სტუდენტი წარმატებით ჩაირიცხა!");
        }
        catch (Exception ex) { Error(ex.Message); }
        Pause();
    }

    static async Task SetGradeAsync()
    {
        Console.Clear();
        Header("ნიშნის დაყენება");

        var studentId = ReadInt("სტუდენტის ID");
        var courseId = ReadInt("კურსის ID");
        var grade = ReadDouble("ნიში (0-100)");

        try
        {
            await _studentService.SetGradeAsync(studentId, courseId, grade);
            Success("ნიში წარმატებით დაყენდა!");
        }
        catch (Exception ex) { Error(ex.Message); }
        Pause();
    }

    static async Task JoinClubAsync()
    {
        Console.Clear();
        Header("კლუბში გაწევრიანება");

        var studentId = ReadInt("სტუდენტის ID");
        var clubId = ReadInt("კლუბის ID");

        Console.WriteLine("  პოზიცია:");
        foreach (var v in Enum.GetValues<Position>())
            Console.WriteLine($"    {(int)v}. {v}");
        var pos = (Position)ReadInt("აირჩიე");

        try
        {
            await _studentService.JoinClubAsync(studentId, clubId, pos);
            Success("სტუდენტი კლუბში დაემატა!");
        }
        catch (Exception ex) { Error(ex.Message); }
        Pause();
    }

    static async Task AwardScholarshipAsync()
    {
        Console.Clear();
        Header("სტიპენდიის მინიჭება");

        var studentId = ReadInt("სტუდენტის ID");
        var scholarshipId = ReadInt("სტიპენდიის ID");
        var awarded = ReadDate("მინიჭების თარიღი (dd.MM.yyyy)");
        var expiry = ReadDate("გასვლის თარიღი (dd.MM.yyyy)");

        try
        {
            await _studentService.AwardScholarshipAsync(studentId, scholarshipId, awarded, expiry);
            Success("სტიპენდია მინიჭებულია!");
        }
        catch (Exception ex) { Error(ex.Message); }
        Pause();
    }

    static async Task DeleteStudentAsync()
    {
        Console.Clear();
        Header("სტუდენტის წაშლა");

        var id = ReadInt("სტუდენტის ID");
        Console.Write("  დარწმუნებული ხარ? (y/n): ");
        if (Console.ReadLine()?.ToLower() != "y") { Info("გაუქმებულია."); Pause(); return; }

        try
        {
            await _studentService.DeleteStudentAsync(id);
            Success("სტუდენტი წაიშალა!");
        }
        catch (Exception ex) { Error(ex.Message); }
        Pause();
    }


    // ══════════════════════════════════════════════════════════════════
    //                     პროფესორების მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task ProfessorMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║          პროფესორების მართვა            ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. პროფესორის დამატება                 ║");
            Console.WriteLine("║  2. ყველა პროფესორის ნახვა              ║");
            Console.WriteLine("║  3. კურსზე მინიჭება                     ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddProfessorAsync(); break;
                case "2": await ListProfessorsAsync(); break;
                case "3": await AssignToCourseAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddProfessorAsync()
    {
        Console.Clear();
        Header("პროფესორის დამატება");

        var email = Read("ელ-ფოსტა");
        Console.WriteLine("  აკადემიური წოდება:");
        foreach (var v in Enum.GetValues<AcademicRank>())
            Console.WriteLine($"    {(int)v}. {v}");
        var rank = (AcademicRank)ReadInt("აირჩიე");
        var name = Read("სრული სახელი");
        var spec = Read("სპეციალობა");
        var years = ReadInt("გამოცდილება (წლები)");
        var phone = Read("ტელეფონი");
        var salary = ReadDecimal("ხელფასი");

        var prof = await _professorService.CreateProfessorAsync(
            email, rank, name, spec, years, phone, salary);

        Success($"პროფესორი დაემატა! ID: {prof.Id}");
        Pause();
    }

    static async Task ListProfessorsAsync()
    {
        Console.Clear();
        Header("ყველა პროფესორი");

        var professors = await _professorService.GetAllProfessorsAsync();
        if (professors.Count == 0) { Info("პროფესორი არ მოიძებნა."); Pause(); return; }

        Console.WriteLine($"  {"ID",-5} {"სახელი",-25} {"წოდება",-20} {"სპეციალობა",-25}");
        Console.WriteLine(new string('─', 78));
        foreach (var p in professors)
        {
            Console.WriteLine($"  {p.Id,-5} {p.ProfessorProfile?.FullName,-25} {p.AcademicRank,-20} {p.ProfessorProfile?.Specialization,-25}");
            foreach (var ct in p.CourseTeachers)
                Console.WriteLine($"       📖 {ct.Course?.CourseName}  [{ct.Role}]");
        }
        Pause();
    }

    static async Task AssignToCourseAsync()
    {
        Console.Clear();
        Header("კურსზე მინიჭება");

        var profId = ReadInt("პროფესორის ID");
        var courseId = ReadInt("კურსის ID");

        Console.WriteLine("  როლი:");
        foreach (var v in Enum.GetValues<Role>())
            Console.WriteLine($"    {(int)v}. {v}");
        var role = (Role)ReadInt("აირჩიე");

        try
        {
            await _professorService.AssignToCourseAsync(profId, courseId, role);
            Success("პროფესორი კურსს მიენიჭა!");
        }
        catch (Exception ex) { Error(ex.Message); }
        Pause();
    }


    // ══════════════════════════════════════════════════════════════════
    //                     ფაკულტეტების მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task FacultyMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║          ფაკულტეტების მართვა            ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. ფაკულტეტის დამატება                 ║");
            Console.WriteLine("║  2. ყველა ფაკულტეტის ნახვა              ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddFacultyAsync(); break;
                case "2": await ListFacultiesAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddFacultyAsync()
    {
        Console.Clear();
        Header("ფაკულტეტის დამატება");

        var name = Read("ფაკულტეტის სახელი");
        var building = Read("კორპუსი");
        var year = ReadInt("დაარსების წელი");
        var dean = Read("დეკანის სახელი");
        var email = Read("დეკანის ელ-ფოსტა");
        var office = Read("ოფისი");

        var faculty = await _facultyService.CreateFacultyAsync(
            name, building, year, dean, email, office);

        Success($"ფაკულტეტი დაემატა! ID: {faculty.Id}");
        Pause();
    }

    static async Task ListFacultiesAsync()
    {
        Console.Clear();
        Header("ყველა ფაკულტეტი");

        var faculties = await _facultyService.GetAllFacultiesAsync();
        if (faculties.Count == 0) { Info("ფაკულტეტი არ მოიძებნა."); Pause(); return; }

        foreach (var f in faculties)
        {
            Console.WriteLine($"\n  🏛  [{f.Id}] {f.Name}");
            Console.WriteLine($"      კორპუსი: {f.Building}  |  დაარსდა: {f.EstablishedYear}");
            Console.WriteLine($"      დეკანი:  {f.FacultyDean?.FullName}  ({f.FacultyDean?.OfficeRoom})");
            Console.WriteLine($"      კურსები: {f.Courses.Count}");
        }
        Pause();
    }


    // ══════════════════════════════════════════════════════════════════
    //                       კურსების მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task CourseMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║            კურსების მართვა              ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. კურსის დამატება                     ║");
            Console.WriteLine("║  2. კურსის სტუდენტები                   ║");
            Console.WriteLine("║  3. სახელმძღვანელოს მიბმა               ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddCourseAsync(); break;
                case "2": await ListCourseStudentsAsync(); break;
                case "3": await AddTextbookAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddCourseAsync()
    {
        Console.Clear();
        Header("კურსის დამატება");

        var name = Read("კურსის სახელი");
        var code = Read("კოდი (მაგ: CS-201)");
        var credits = ReadInt("კრედიტები");
        var semester = Read("სემესტრი");
        var facultyId = ReadInt("ფაკულტეტის ID");

        var course = await _courseService.CreateCourseAsync(
            name, code, credits, semester, facultyId);

        Success($"კურსი დაემატა! ID: {course.Id}");
        Pause();
    }

    static async Task ListCourseStudentsAsync()
    {
        Console.Clear();
        Header("კურსის სტუდენტები");

        var courseId = ReadInt("კურსის ID");
        var enrollments = await _courseService.GetCourseStudentsAsync(courseId);

        if (enrollments.Count == 0) { Info("სტუდენტი არ მოიძებნა."); Pause(); return; }

        Console.WriteLine($"\n  {"ID",-5} {"სახელი",-25} {"ნიში",-8} {"სტატუსი",-12}");
        Console.WriteLine(new string('─', 55));
        foreach (var e in enrollments)
            Console.WriteLine($"  {e.Student?.Id,-5} {e.Student?.StudentProfile?.FullName,-25} {(e.Grade.HasValue ? e.Grade.ToString() : "—"),-8} {e.Status,-12}");

        Pause();
    }

    static async Task AddTextbookAsync()
    {
        Console.Clear();
        Header("სახელმძღვანელოს მიბმა");

        var courseId = ReadInt("კურსის ID");
        var textbookId = ReadInt("სახელმძღვანელოს ID");
        Console.Write("  სავალდებულოა? (y/n): ");
        var mandatory = Console.ReadLine()?.ToLower() == "y";

        try
        {
            await _courseService.AddTextbookAsync(courseId, textbookId, mandatory);
            Success("სახელმძღვანელო მიება!");
        }
        catch (Exception ex) { Error(ex.Message); }
        Pause();
    }


    // ══════════════════════════════════════════════════════════════════
    //                      გამოცდების მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task ExamMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           გამოცდების მართვა             ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. გამოცდის დამატება                   ║");
            Console.WriteLine("║  2. ყველა გამოცდის ნახვა                ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddExamAsync(); break;
                case "2": await ListExamsAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddExamAsync()
    {
        Console.Clear();
        Header("გამოცდის დამატება");

        var subject = Read("საგანი");
        var date = ReadDate("გამოცდის თარიღი (dd.MM.yyyy)");
        Console.WriteLine("  ტიპი:");
        foreach (var v in Enum.GetValues<ExamType>())
            Console.WriteLine($"    {(int)v}. {v}");
        var type = (ExamType)ReadInt("აირჩიე");
        var room = Read("დარბაზი");
        var total = ReadInt("მონაწილეთა რაოდენობა");
        var avg = ReadDouble("საშუალო ნიში");
        var highest = ReadDouble("უმაღლესი ნიში");
        var lowest = ReadDouble("უდაბლესი ნიში");
        var pass = ReadInt("გადალახა");
        var fail = ReadInt("ვერ გადალახა");

        var exam = await _examService.CreateExamWithResultAsync(
            subject, date, type, room, total, avg, highest, lowest, pass, fail);

        Success($"გამოცდა დაემატა! ID: {exam.Id}");
        Pause();
    }

    static async Task ListExamsAsync()
    {
        Console.Clear();
        Header("ყველა გამოცდა");

        var exams = await _examService.GetAllExamsAsync();
        if (exams.Count == 0) { Info("გამოცდა არ მოიძებნა."); Pause(); return; }

        foreach (var e in exams)
        {
            Console.WriteLine($"\n  📝 [{e.Id}] {e.Subject}  |  {e.ExamType}  |  {e.ExamDate:dd/MM/yyyy}  |  დარბ: {e.Room}");
            Console.WriteLine($"      მონაწ: {e.ExamResult?.TotalParticipants}  |  საშ: {e.ExamResult?.AverageScore:F1}  |  გადალახა: {e.ExamResult?.PassCount}  |  ვერ: {e.ExamResult?.FailCount}");
        }
        Pause();
    }


    // ══════════════════════════════════════════════════════════════════
    //                        დამხმარე მეთოდები
    // ══════════════════════════════════════════════════════════════════
    static string Read(string label)
    {
        Console.Write($"  {label}: ");
        return Console.ReadLine() ?? "";
    }

    static int ReadInt(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            if (int.TryParse(Console.ReadLine(), out int val)) return val;
            Error("მხოლოდ რიცხვი შეიყვანე!");
        }
    }

    static double ReadDouble(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            if (double.TryParse(Console.ReadLine(), out double val)) return val;
            Error("მხოლოდ რიცხვი შეიყვანე!");
        }
    }

    static decimal ReadDecimal(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal val)) return val;
            Error("მხოლოდ რიცხვი შეიყვანე!");
        }
    }

    static DateTime ReadDate(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy",
                null, System.Globalization.DateTimeStyles.None, out DateTime val)) return val;
            Error("ფორმატი: dd.MM.yyyy  (მაგ: 15.06.2024)");
        }
    }

    static void Header(string text)
    {
        Console.WriteLine($"──── {text} ────\n");
    }

    static void Success(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✅ {text}");
        Console.ResetColor();
    }

    static void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ❌ {text}");
        Console.ResetColor();
    }

    static void Info(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n  ℹ  {text}");
        Console.ResetColor();
    }

    static void Pause()
    {
        Console.Write("\n  Enter-ი გასაგრძელებლად...");
        Console.ReadLine();
    }
}