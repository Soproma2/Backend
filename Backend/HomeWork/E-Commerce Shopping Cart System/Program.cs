using E_Commerce_Shopping_Cart_System.Menus;

namespace E_Commerce_Shopping_Cart_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shopping Cart System");
            while (true)
            {
                MainMenu.Show();
            }
        }
    }
}
