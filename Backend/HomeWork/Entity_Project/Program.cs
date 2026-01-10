using Entity_Project.Data;
using Entity_Project.Menus;

DataContext _db = new DataContext();
static void Main(string[] args)
{
    Console.WriteLine("═══════════════════════════════════════");
    Console.WriteLine("Shopping Cart System");
    Console.WriteLine("═══════════════════════════════════════");
    while (true)
    {
        MainMenu.Show();
    }
}