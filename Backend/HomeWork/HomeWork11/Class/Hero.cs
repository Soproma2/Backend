using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11.Class
{
    public class Hero : Character
    {

        public override void Attack(Character target)
        {
            target.takeDamage(20);
            Console.WriteLine($"{Name} uses a {Weapon} and deals 20 damage to {target.Name}. ");
        }
    }

}
