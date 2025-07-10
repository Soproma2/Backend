using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11.Class
{
    public class Villain : Character
    {
        public override void Attack(Character target)
        {
            target.takeDamage(25);
            Console.WriteLine($"{Name} uses a {Weapon} and deals 25 damage to {target.Name}. ");
        }
    }
}
