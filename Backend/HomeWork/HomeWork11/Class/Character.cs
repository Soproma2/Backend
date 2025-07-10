using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11.Class
{

     
    //📌 ტექნიკური მოთხოვნები:
    //1. აბსტრაქცია
    //შექმენი აბსტრაქტული კლასი Character, რომელიც წარმოადგენს ზოგად პერსონაჟს.
    //უნდა შეიცავდეს შემდეგ თვისებებს:
    //string Name
    //int Health
    //უნდა ჰქონდეს შემდეგი მეთოდები:
    //abstract void Attack(Character target) – შეტევის აბსტრაქტული მეთოდი.
    //void TakeDamage(int damage) – რომელიც ამცირებს პერსონაჟის სიცოცხლეს.
    //bool IsAlive – რომელიც ამოწმებს პერსონაჟი ცოცხალია თუ არა.

    public abstract class Character
    {
        public string Name { get; set; }
        private int health;

        public int Health
        {
            get { return health; }
            private set { health = 100;}
        }

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

        public bool IsAlive
        {
            get {  return Health > 0;}
        }
    }



    //2. მემკვიდრეობა
    //შექმენი ორი კლასი Hero და Villain, რომლებიც მემკვიდრეობას იღებენ Character-ისგან.
    //თითოეულმა კლასმა უნდა დააიმპლემენტოს საკუთარი ვერსია Attack მეთოდისა.მაგალითად:
    //Hero იყენებს ხმალს (sword) და აზიანებს მოწინააღმდეგეს 20 ქულით.
    //Villain იყენებს ჯადოს (fireball) და აზიანებს მოწინააღმდეგეს 25 ქულით.


    public class Hero : Character
    {
        
        public override void Attack(Character target)
        {
            
        }
    }

    public class Villain : Character
    {
        public override void Attack(Character target)
        {
            throw new NotImplementedException();
        }
    }

}
