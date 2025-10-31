using E_Commerce_Shopping_Cart_System.Menus;

namespace E_Commerce_Shopping_Cart_System
{
    internal class Program
    {
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
    }
}
