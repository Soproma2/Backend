namespace HomeWork19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2.ფუნქციონალი რომელიც უნდა განახორციელოთ:
            //პროდუქტის დამატება -კალათაში პროდუქტის დამატება რაოდენობით
            //პროდუქტის წაშლა - კონკრეტული პროდუქტის სრულად ამოღება კალათიდან
            //რაოდენობის განახლება -არსებული პროდუქტის რაოდენობის შეცვლა
            //კალათის ნახვა - ყველა პროდუქტის ჩვენება დეტალებით
            //ჯამური ღირებულება - კალათაში არსებული პროდუქტების ჯამური ფასის გამოთვლა


            List<Product> products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Price=1200, Category="Electronics"},
                new Product{Id=2, Name="Smartphone", Price=800, Category="Electronics"},
                new Product{Id=3, Name="Jeans", Price=50, Category="Clothing"},
                new Product{Id=4, Name="T-Shirt", Price=20, Category="Clothing"},
                new Product{Id=5, Name="Bread", Price=2, Category="Food"},
                new Product{Id=6, Name="Milk", Price=3, Category="Food"},
                new Product{Id=7, Name="Headphones", Price=150, Category="Electronics"},
                new Product{Id=8, Name="Jacket", Price=100, Category="Clothing"},
                new Product{Id=9, Name="Chocolate", Price=5, Category="Food"},
                new Product{Id=10, Name="Monitor", Price=300, Category="Electronics"}
            };

            while (true)
            {
                Console.WriteLine("--- Shopping Cart Menu ---");
                Console.WriteLine();
                Console.WriteLine("1. Add product to cart");
                Console.WriteLine("2. Remove product from cart");
                Console.WriteLine("3. Update product quantity");
                Console.WriteLine("4. View cart");
                Console.WriteLine("5. Show most expensive product");
                Console.WriteLine("6. Show product count by category");
                Console.WriteLine("7. Search products in cart");
                Console.WriteLine("8. Show history");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
            }



        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCart
    {
        private List<CartItem> cartItems = new List<CartItem>();

        public void AddProduct()
        {

        }

        public void RemoveProduct()
        {

        }

        public void UpdateQuantity()
        {

        }

        public void ViewCart()
        {

        }

        //public decimal GetTotalPrice()
        //{

        //}

        public void ShowMostExpensiveProduct()
        {

        }

        public void ShowProductCountByCategory()
        {

        }

        //public decimal GetTotalPriceWithDiscount()
        //{

        //}

        public void SearchProducts()
        {

        }

        private void AddHistory()
        {

        }

        public void ShowHistory()
        {

        }
    }
}
