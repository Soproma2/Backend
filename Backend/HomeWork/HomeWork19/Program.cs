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

            ShoppingCart cart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("--- Shopping Cart Menu ---");
                Console.WriteLine();
                Console.WriteLine("1. Add product to cart");
                Console.WriteLine("2. Remove product from cart");
                Console.WriteLine("3. Update product quantity");
                Console.WriteLine("4. View cart");
                Console.WriteLine("5. Show most expensive product in cart");
                Console.WriteLine("6. Show product count by category in cart");
                Console.WriteLine("7. Search products in cart");
                Console.WriteLine("8. Show history");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Available products: ");
                        foreach(var p in products)
                        {
                            Console.WriteLine($"{p.Id}. {p.Name} - {p.Category} - {p.Price}$");
                        }

                        Console.Write("Enter product ID: ");
                        int addId = int.Parse(Console.ReadLine());
                        Console.Write("Enter quantity: ");
                        int qty = int.Parse(Console.ReadLine());
                        var prodToAdd = products.FirstOrDefault(p=>p.Id == addId);
                        if(prodToAdd != null)
                        {
                            cart.AddProduct(prodToAdd, qty);
                        }
                        else
                        {
                            Console.WriteLine("Product not found");
                        }
                            break;

                    case "2":
                        Console.Clear();
                        Console.Write("Enter product ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        cart.RemoveProduct(removeId);
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Enter product ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new quantity: ");
                        int newQty = int.Parse(Console.ReadLine());
                        cart.UpdateQuantity(updateId, newQty);
                        break;

                    case "4":
                        Console.Clear();
                        cart.ViewCart();
                        break;

                    case "5":
                        Console.Clear();
                        cart.ShowMostExpensiveProduct();
                        break;

                    case "6":
                        Console.Clear();
                        cart.ShowProductCountByCategory();
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("Enter procduct name to search: ");
                        string search = Console.ReadLine();
                        cart.SearchProducts(search);
                        break;

                    case "8":
                        Console.Clear();
                        cart.ShowHistory();
                        break;

                    case "9":
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice!");
                        break;
                        

                }
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
        private Queue<string> history = new Queue<string>();
        public void AddProduct(Product product, int quantity)
        {
            var item = cartItems.FirstOrDefault(p=>p.Product.Id == product.Id);
            if (item != null)
            {
                item.Quantity += quantity;
                AddHistory($"Updated quantity of '{product.Name}' to {item.Quantity}");
            }
            else
            {
                cartItems.Add(new CartItem { Product = product, Quantity = quantity });
                AddHistory($"Added '{product.Name}' x{quantity}");
            }
        }

        public void RemoveProduct(int productID)
        {
            var item = cartItems.FirstOrDefault(p=>p.Product.Id == productID);
            if (item != null)
            {
                cartItems.Remove(item);
                AddHistory($"Removed '{item.Product.Name}'");
            }
            else
            {
                Console.WriteLine("Product not found in cart");
            }
        }

        public void UpdateQuantity(int productID, int newQuantity)
        {
            var item = cartItems.FirstOrDefault(p=>p.Product.Id == productID);
            if (item != null)
            {
                item.Quantity = newQuantity;
                AddHistory($"Updated quantity of '{item.Product.Name}'to {newQuantity}");
            }
            else
            {
                Console.WriteLine("Product not found in cart! First add the product to the list.");            }
        }

        public void ViewCart()
        {
            if (!cartItems.Any())
            {
                Console.WriteLine("Cart is empty");
                return;
            }

            foreach (var item in cartItems)
            {
                Console.WriteLine($"{item.Product.Name} - {item.Product.Category} - {item.Product.Price:C} x {item.Quantity} = {(item.Product.Price * item.Quantity)}$");
                Console.WriteLine($"Total: {GetTotalPrice()}$");
                Console.WriteLine($"Total with discount: {GetTotalPriceWithDiscount()}$");
            }
        }

        public decimal GetTotalPrice()
        {
            return cartItems.Sum(c => c.Product.Price * c.Quantity);
        }

        public decimal GetTotalPriceWithDiscount()
        {
            decimal total = GetTotalPrice();
            if (total > 100)
            {
                total *= 0.9m;
            }
            return total;
        }

        public void ShowMostExpensiveProduct()
        {
            var item = cartItems.OrderByDescending(c=>c.Product.Price).FirstOrDefault();
            if (item != null)
            {
                Console.WriteLine($"Most expensive product: {item.Product.Name} - {item.Product.Price}$");
            }
            else
            {
                Console.WriteLine("Sold out products!");
            }
        }

        public void ShowProductCountByCategory()
        {
            var grouped = cartItems.GroupBy(c => c.Product.Category)
                .Select(s=> new
                {
                    category = s.Key,
                    count = s.Sum(c=>c.Quantity)
                });

            foreach(var g in grouped)
            {
                Console.WriteLine($"{g.category}: {g.count} items");
            }
        }


        public void SearchProducts(string name)
        {
            var results = cartItems.Where(c => c.Product.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Product);

            if (!results.Any())
            {
                Console.WriteLine("No products found");
                return;
            }

            foreach(var p in results)
            {
                Console.WriteLine($"{p.Name} - {p.Category} - {p.Price}$");
            }
        }

        private void AddHistory(string action)
        {
            history.Enqueue(action);
            if (history.Count > 5)
            {
                history.Dequeue();
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("Last Operations: ");
            foreach (var h in history)
            {
                Console.WriteLine(h);
            }
        }
    }
}
