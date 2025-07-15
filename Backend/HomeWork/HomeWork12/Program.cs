using HomeWork12.Class;
using System;

namespace HomeWork12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //🔧 დავალება: შეიმუშავეთ ProductWeight კლასი
            //📘 ბიზნეს მოთხოვნა:
            //თქვენ ქმნით სისტემას ლოგისტიკური კომპანიისთვის, რომელსაც სჭირდება პროდუქტების წონების შედარება და კომბინაცია.პროდუქტებს შეიძლება ჰქონდეთ წონა სხვადასხვა ერთეულებში(მაგ.კილოგრამი, გრამი). კომპანია ითხოვს, რომ მხოლოდ ერთი და იმავე ერთეულით გამოხატული პროდუქტების წონები იყოს შედარებული ან შერწყმული.

            //✅ მიზნები:
            //            შექმენით ProductWeight კლასი, რომელიც:

            //            გადატვირთავს ყველა ოპერატორს შესაბამისი ოპერაციებისათვის;

            //            განახორციელებს IComparable<ProductWeight> ინტერფეისს, წონის მნიშვნელობაზე დაყრდნობით;

            //            უზრუნველყოფს, რომ ოპერაციები მხოლოდ მაშინ იყოს დაშვებული, როცა ერთეულები ემთხვევა;

            //            აგდებს გამონაკლისს(exception-ს), თუ ერთეულები არ ემთხვევა;

            //            მოიცავს სუფთა და გასაგებ ToString() გამოსახულებას.


            try
            {
                ProductWeight product1 = new ProductWeight(100, "KG");
                ProductWeight product2 = new ProductWeight(120, "KG");

                Console.WriteLine(product1 + product2);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
