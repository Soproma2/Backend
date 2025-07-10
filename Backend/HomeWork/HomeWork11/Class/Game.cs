using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11.Class
{
    internal class Game
    {

    //4. თამაშის კლასი
    //შექმენი კლასი Game, რომელიც აკონტროლებს თამაშის ლოგიკას:
    //ქმნის გმირს და ბოროტმოქმედს.
    //ათამაშებს მათ ერთმანეთთან მანამ, სანამ ერთ-ერთი არ დამარცხდება.
    //ბეჭდავს შეტევის და დაზიანების შეტყობინებებს კონსოლზე.
    //აფიქსირებს გამარჯვებულს.

        private Character hero;
        private Character villain;

        public void Start()
        {
            hero = new Hero()
            {
                Name = "Knight",
                Weapon = "Sword",
                Health = 100
            };

            villain = new Villain()
            {
                Name = "Dark Lord",
                Weapon = "Fireball",
                Health = 100
            };



            Console.WriteLine("Battle Start!");
            Console.WriteLine($"{hero.Name} vs {villain.Name}");
            Console.WriteLine();

            while(hero.IsAlive && villain.IsAlive)
            {
                hero.Attack(villain);
                if (!villain.IsAlive)
                {
                    break;
                }
                hero.Attack(villain);
                if(!villain.IsAlive)
                {
                    break;
                }
                villain.Attack(hero);
                
                Console.WriteLine($"{hero.Name}'s Health: {hero.Health}");
                Console.WriteLine($"{villain.Name}'s Health: {villain.Health}");
                Console.WriteLine();
            }

            Console.WriteLine("Game Over!");
            if (hero.IsAlive)
            {
                Console.WriteLine($"{hero.Name} Wins!");
            }
            else
            {
                Console.WriteLine($"{villain.Name} Wins!");
            }


            Console.WriteLine($"{hero.Name}'s Health: {hero.Health}");
            Console.WriteLine($"{villain.Name}'s Health: {villain.Health}");
        }


    }
}
