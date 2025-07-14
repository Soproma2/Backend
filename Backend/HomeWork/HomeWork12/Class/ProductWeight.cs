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
            var sum = first.Value + second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static ProductWeight operator -(ProductWeight first, ProductWeight second)
        {
            var sum = first.Value - second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static ProductWeight operator *(ProductWeight first, ProductWeight second)
        {
            var sum = first.Value * second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static ProductWeight operator /(ProductWeight first, ProductWeight second)
        {
            var sum = first.Value / second.Value;
            return new ProductWeight(sum, second.Unit);
        }

        public static bool operator >(ProductWeight first, ProductWeight second)
        {
            return first.Value > second.Value;
        }

        public static bool operator <(ProductWeight first, ProductWeight second)
        {
            return first.Value < second.Value;
        }

        public static bool operator >=(ProductWeight first, ProductWeight second)
        {
            return first.Value >= second.Value;
        }

        public static bool operator <=(ProductWeight first, ProductWeight second)
        {
            return first.Value <= second.Value;
        }

        public static bool operator ==(ProductWeight first, ProductWeight second)
        {
            return first.Value == second.Value;
        }

        public static bool operator >(ProductWeight first, ProductWeight second)
        {
            return first.Value > second.Value;
        }
        public static bool operator !=(ProductWeight first, ProductWeight second)
        {
            return first.Value != second.Value;
        }

        public override string ToString() => $"{Value} {Unit};";




        public int CompareTo(ProductWeight? other)
        {
            throw new NotImplementedException();
        }
    }
}
