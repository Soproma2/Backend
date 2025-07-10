using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11.Class
{
    public abstract class Character
    {
        public string Name { get; set; }
        private int health;

        public int Health { get; set; }

        public string Weapon { get; set; }
        public abstract void Attack(Character target);

        public void takeDamage(int damage)
        {
            if (damage > 0)
            {
                Health -= damage;
                if (Health < 0)
                {
                    Health = 0;
                }
            }
        }

        public bool IsAlive => Health > 0;
    }
}
