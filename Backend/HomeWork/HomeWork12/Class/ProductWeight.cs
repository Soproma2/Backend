using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12.Class
{
    //✅ მიზნები:
    //            შექმენით ProductWeight კლასი, რომელიც:
    //            გადატვირთავს ყველა ოპერატორს შესაბამისი ოპერაციებისათვის;
    //            განახორციელებს IComparable<ProductWeight> ინტერფეისს, წონის მნიშვნელობაზე დაყრდნობით;
    //            უზრუნველყოფს, რომ ოპერაციები მხოლოდ მაშინ იყოს დაშვებული, როცა ერთეულები ემთხვევა;
    //            აგდებს გამონაკლისს(exception-ს), თუ ერთეულები არ ემთხვევა;
    //            მოიცავს სუფთა და გასაგებ ToString() გამოსახულებას.
    public class ProductWeight : IComparable<ProductWeight>
    {
        public decimal Value { get; set; }
        public string Unit { get; set; }

        public ProductWeight(decimal value, string unit)
        {
            Value = value;
            Unit = unit;
        }

        public static ProductWeight operator +(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first,second);
            var sum = first.Value + second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static ProductWeight operator -(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            var sum = first.Value - second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static ProductWeight operator *(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            var sum = first.Value * second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static ProductWeight operator /(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            var sum = first.Value / second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static bool operator >(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            return first.Value > second.Value;
        }

        public static bool operator <(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            return first.Value < second.Value;
        }

        public static bool operator >=(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            return first.Value >= second.Value;
        }

        public static bool operator <=(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            return first.Value <= second.Value;
        }

        public static bool operator ==(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            return first.Value == second.Value;
        }

        public static bool operator !=(ProductWeight first, ProductWeight second)
        {
            ValidateSameUnit(first, second);
            return first.Value != second.Value;
        }

        public override string ToString() => $"{Value} {Unit};";




        public int CompareTo(ProductWeight other)
        {
            ValidateSameUnit(other);
            return Value.CompareTo(other.Value);
        }

        private static void ValidateSameUnit(ProductWeight Unit1, ProductWeight Unit2)
        {
            if (Unit1.Unit != Unit2.Unit)
            {
                throw new InvalidOperationException("The system can't handle different measurement units!");
            }
        }

        private void ValidateSameUnit(ProductWeight other)
        {
            if (Unit != other.Unit)
            {
                throw new InvalidOperationException("The system can't handle different measurement units!");
            }
        }
    }
}
