using System;
using System.Collections.Generic;

namespace HomeWork15
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> intlist = new List<int>() { 1,1,134,12,223,441,123,12};
            Class1.Mydistinct(intlist);
            Class1.MyReverse(intlist);
            Class1.MyReverse(intlist, x => x % 2 == 0);

            //🔹 3. MyReverse(List<int> source, Func<int, bool> predicate)
            //აღწერა:
            //დაბრუნეთ ახალი სია, რომელიც შეიცავს მხოლოდ იმ ელემენტებს, რომლებიც აკმაყოფილებენ პირობას (predicate) და არის შებრუნებული მიმდევრობით.

            //მაგ: [1, 2, 3, 4] და x => x % 2 == 0 → [4, 2]

            //🔹 4. MyAny(List<int> source, Func<int, bool> predicate)
            //აღწერა:
            //დააბრუნეთ true, თუ არსებობს მინიმუმ ერთი ელემენტი, რომელიც აკმაყოფილებს მოცემულ პირობას.

            //🔹 5. MyAll(List<int> source, Func<int, bool> predicate)
            //აღწერა:
            //დააბრუნეთ true, თუ ყველა ელემენტი აკმაყოფილებს მოცემულ პირობას.

            //🔹 6. MyMax(List<int> source)
            //აღწერა:
            //დააბრუნეთ სიაში არსებული მაქსიმალური მნიშვნელობა.

            //შენიშვნა:
            //თუ სია ცარიელია, უნდა ისროლოს გამონაკლისი (ArgumentException).

            //🔹 7. MyMin(List<int> source)
            //აღწერა:
            //დააბრუნეთ სიაში არსებული მინიმალური მნიშვნელობა.

            //შენიშვნა:
            //თუ სია ცარიელია, უნდა ისროლოს გამონაკლისი (ArgumentException).

            //🔹 8. MyTake(List<int> source, int count)
            //აღწერა:
            //დააბრუნეთ სია, რომელიც შეიცავს მხოლოდ პირველ count რაოდენობის ელემენტს.

            //მაგ: MyTake([1,2,3,4,5], 3) → [1,2,3]

            //🔹 9. MySkip(List<int> source, int count)
            //აღწერა:
            //დაბრუნეთ სია, რომელიც შეიცავს ყველა იმ ელემენტს, რაც იწყება count ინდექსიდან.

            //მაგ: MySkip([1,2,3,4,5], 2) → [3,4,5]🔹
           
        }
    }
}
