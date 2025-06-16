namespace HomeWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დავალება 1 (ლექციის განმავლობაში ნაჩვენები ოპერატორების გამოყენებით ჩაატარეთ ყველა მათემატიკური ოპერაცია შეკრიბეთ გამოაკელით გაამრავლეთ და გაყავით ორი რიცხვი.პროგრამის მუშაობის რეალიზაცია მოახდინეთ კონსოლში.)

            // მინიჭების ოპერატორი
            int x = 10;
            Console.WriteLine(x);

            // შედარების ოპერატორები
            Console.WriteLine(5 == 5); //true
            Console.WriteLine(10>5); //true
            Console.WriteLine(10>10); //false
            Console.WriteLine(8<12); //true
            Console.WriteLine(10>=7); //true
            Console.WriteLine(10<=10); //true
            Console.WriteLine(10<=8); //false
            Console.WriteLine(3!=5); //true

            //არითმეტიკული
            Console.WriteLine(11+14); //25
            Console.WriteLine(15-12); //3
            Console.WriteLine(35*20); //700
            Console.WriteLine(42 / 6); //7

            int y = 0;
            y += 2;
            Console.WriteLine(y); //2
            y -= 3;
            Console.WriteLine(y); //-1
            y *= -5;
            Console.WriteLine(y); //5
            y /= 5;
            Console.WriteLine(y); //1

            y = y++;
            Console.WriteLine(y); //1
            y = ++y;
            Console.WriteLine(y); //2
            y = y--;
            Console.WriteLine(y); //2
            y = --y;
            Console.WriteLine(y); //1

            //დამხმარე ოპერატორები
            Console.WriteLine(12>10 && 2>1); // true
            Console.WriteLine(12<10 || 2>1); // true



        }
    }
}
