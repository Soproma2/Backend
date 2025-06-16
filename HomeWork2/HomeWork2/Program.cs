namespace HomeWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დავალება 1 (ლექციის განმავლობაში ნაჩვენები ოპერატორების გამოყენებით ჩაატარეთ ყველა მათემატიკური ოპერაცია შეკრიბეთ გამოაკელით გაამრავლეთ და გაყავით ორი რიცხვი.პროგრამის მუშაობის რეალიზაცია მოახდინეთ კონსოლში.)

            //// მინიჭების ოპერატორი
            //int x = 10;
            //Console.WriteLine(x);

            //// შედარების ოპერატორები
            //Console.WriteLine(5 == 5); //true
            //Console.WriteLine(10 > 5); //true
            //Console.WriteLine(10 > 10); //false
            //Console.WriteLine(8 < 12); //true
            //Console.WriteLine(10 >= 7); //true
            //Console.WriteLine(10 <= 10); //true
            //Console.WriteLine(10 <= 8); //false
            //Console.WriteLine(3 != 5); //true

            ////არითმეტიკული
            //Console.WriteLine(11 + 14); //25
            //Console.WriteLine(15 - 12); //3
            //Console.WriteLine(35 * 20); //700
            //Console.WriteLine(42 / 6); //7

            //int y = 0;
            //y += 2;
            //Console.WriteLine(y); //2
            //y -= 3;
            //Console.WriteLine(y); //-1
            //y *= -5;
            //Console.WriteLine(y); //5
            //y /= 5;
            //Console.WriteLine(y); //1

            //y = y++;
            //Console.WriteLine(y); //1
            //y = ++y;
            //Console.WriteLine(y); //2
            //y = y--;
            //Console.WriteLine(y); //2
            //y = --y;
            //Console.WriteLine(y); //1

            ////დამხმარე ოპერატორები
            //Console.WriteLine(12 > 10 && 2 > 1); // true
            //Console.WriteLine(12 < 10 || 2 > 1); // true



            //დავალება 2 (კონსოლიდან მომხმარებელს შემოაყვანინეთ ორი რიცხვი, ეს რიცხვები ერთმანეთს მიუმატეთ გამოაკელით გაამრავლეთ და გაყავით.პროგრამის მუშაობის რეალიზაცია მოახდინეთ კონსოლში.)

            //Console.Write("Enter Fnumber: ");
            //int num1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter Snumber: ");
            //int num2 = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine($"{num1}+{num2}={num1 + num2}");
            //Console.WriteLine($"{num1}-{num2}={num1 - num2}");
            //Console.WriteLine($"{num1}*{num2}={num1 * num2}");
            //Console.WriteLine($"{num1}/{num2}={num1 / num2}");



            //დავალება 3 (მოცემულია int ტიპის ცვლადი რომელიც ინახავს რაღაც რიცხვს.ლექციაში ნაჩვენები ოპერატორების გამოყენებით გაზარდეთ ამ ცვლდის მნიშვნელობა 3-ჯერ.)
            //int z = 5;
            //Console.WriteLine(z*3);



            //დავალება 4 (მოცემულია int ტიპის ცვლადი რომელიც ინახავს რაღაც რიცხვს.ლექციაში ნაჩვენები ოპერატორების გამოყენებით გაზარდეთ ამ ცვლდის მნიშვნელობა 2-ით და შეამცირეთ 4-ით.)
            //int j = 10;
            //j += 2;
            //j -= 4;
            //Console.WriteLine(j);



            //დავალება 5 (დაწერეთ პროგრამა სადაც მომხმარებელს შემოჰყავს ორი რიცხვი.პროგრამა ერთმანეთს ადარებს ამ ორ რიცხვს და გამოაქვს შესაბამისი შეტყობინება.(ეს რიცხვები ტოლია ან პირველი მეტია მეორეზე ან მეორე მტია პირველზე))
            //Console.Write("Enter Fnumber: ");
            //int userNum1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter Snumber: ");
            //int userNum2 = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine($"{userNum1} == {userNum2} --> {userNum1 == userNum2}");
            //Console.WriteLine($"{userNum1} > {userNum2} --> {userNum1 > userNum2}");
            //Console.WriteLine($"{userNum2} > {userNum1} --> {userNum2 > userNum1}");



            //დავალება 6 (დაწერეთ პროგრამა სადაც მომხმარებელს შემოჰყავს რიცხვი, თუ ეს რიცხვი მეტია 5-ზე  და ნაკლებია 10-ზე,კონსოლში დაიბეჭდება შესაბამსი შეტყობინება (რიცხვი მეტია 5-ზე და ნაკლებია 10-ზე),წინააღმდეგ შემთხვევაში დაიბეჭდება(უცნობი რიცხვი))

            //Console.Write("Enter number: ");
            //int userNum = Convert.ToInt32(Console.ReadLine());
            //if(userNum > 5 &&  userNum < 10)
            //{
            //    Console.WriteLine($"{userNum}>5 and {userNum}<10");
            //}
            //else
            //{
            //    Console.WriteLine(userNum);
            //}



            //დავალება 7 (დაწერეთ პროგრამა სადაც მომხმარებელს შემოჰყავს რიცხვი თუ ეს რიცხვი ტოლია 5-ის ან ტოლია 10-ის,კონსოლში დაიბეჭდება(რიცხვი უდრის 5-ს ან რიცხვი უდრის 10-ს,წინააღმდეგ შემთხვევაში დაიბეჭდება(უცნობი რიცხვი))

            //Console.Write("Enter number: ");
            //int UserNum = Convert.ToInt32(Console.ReadLine());
            //if (UserNum == 5 || UserNum == 10)
            //{
            //    Console.WriteLine($"{UserNum}=5 or {UserNum}=10");
            //}
            //else
            //{
            //    Console.WriteLine(UserNum);
            //}



            //დავალება 8 (დაწერეთ პროგრამა სადაც მომხმარებელს შემოჰყავს რიცხვი,თუ ეს რიცხვი კენტია დაიბეჭდება (რიცხვი არის კენტი) თუ ლუწია დაიბეჭდება(რიცხვი არის ლუწი).შეგახსენებთ რიცხვები რომლებიც უნაშთოდ იყოფა 2-ზე არის ლუწი რიცხვები.)

            //Console.Write("Enter number: ");
            //int userNumber = Convert.ToInt32(Console.ReadLine());
            //if (userNumber % 2 !=0)
            //{
            //    Console.WriteLine("Number is Odd");
            //}
            //else
            //{
            //    Console.WriteLine("Number is Even");
            //}
        }
    }
}
