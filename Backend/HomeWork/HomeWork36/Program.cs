using HomeWork36.Data;
using HomeWork36.Services;

DataContext _db = new DataContext();
AuthService _authService = new AuthService();
SMTPService _smtpService = new SMTPService();
MotivationService motivationService = new MotivationService(_db, _smtpService);
while (true)
{
    try
    {
        Console.WriteLine("1. register");
        Console.WriteLine("2. verify email");
        Console.WriteLine("3. login");
        Console.WriteLine("4. show users");
        Console.WriteLine("5. Send Email");

        Console.Write("Enter key: ");
        string key = Console.ReadLine();

        if (key == "1")
        {
            _authService.Register();
        }
        else if (key == "2")
        {
            _authService.VerifyEmail();
        }
        else if (key == "3")
        {
            _authService.Login();
        }
        else if (key == "4")
        {
            _authService.ShowUsers();
        }else if(key == "5")
        {
            Console.WriteLine("Enter motivation message:");
            string message = Console.ReadLine();

            motivationService.SendMotivationToAll(message);
        }
        else break;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}