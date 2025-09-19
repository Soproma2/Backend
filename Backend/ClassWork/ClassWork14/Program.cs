namespace ClassWork14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    დავალება.
            //    ააწყეთ მაღაზიის სისტემა
            //    უნდა გქონდეთ პროდუქტები და ქართში უნდა შეგეძლოს ამ პროდუქტების დამატება
            //    (ანუ სტანდარტული მაღაზიის სისტემა)

            //    ფუნქციები:
            //                AddNewProduct,
            //    DeleteProduct,

            //    ---Cart - ისთვის--
            //    AddToCart,
            //    RemoveFromCart,
            //    UpdateProductQuantity,

            //    ყველას უნდა გააჩნდეს ლოგირების სისტემა ანუ უნდა გვქნოდეს
            //    products_logs.txt, cart_logs.txt აქ უნდა ინახებოდეს ინფორმაცია
            //    როდის რა ოპერაცია მოხდა(უნდა ეწეროს რა მოხდა და რა დროს)

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

            Console.WriteLine("1. Add product to cart");
            Console.WriteLine("2. Remove product from cart");
            Console.WriteLine("3. Update product quantity");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Available products: ");
                    foreach (var p in products)
                    {
                        Console.WriteLine($"{p.Id}. {p.Name} - {p.Category} - {p.Price}$");
                    }

                    Console.Write("Enter product ID: ");
                    int addId = int.Parse(Console.ReadLine());
                    Console.Write("Enter quantity: ");
                    int qty = int.Parse(Console.ReadLine());
                    var prodToAdd = products.FirstOrDefault(p => p.Id == addId);
                    if (prodToAdd != null)
                    {
                        cart.AddNewProduct(prodToAdd, qty);
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
                    cart.DeleteProduct(removeId);
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Enter product ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new quantity: ");
                    int newQty = int.Parse(Console.ReadLine());
                    cart.UpdateProductQuantity(updateId, newQty);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice!");
                    break;
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
            string fileName = "cartHistory.txt";
            public void AddNewProduct(Product product, int quantity)
            {
                var item = cartItems.FirstOrDefault(p => p.Product.Id == product.Id);
                if (item != null)
                {
                    item.Quantity += quantity;
                    WriteHistoryToFile($"Updated quantity of '{product.Name}' to {item.Quantity}");
                }
                else
                {
                    cartItems.Add(new CartItem { Product = product, Quantity = quantity });
                    WriteHistoryToFile($"Added '{product.Name}' x{quantity}");
                }
            }

            public void DeleteProduct(int productID)
            {
                var item = cartItems.FirstOrDefault(p => p.Product.Id == productID);
                if (item != null)
                {
                    cartItems.Remove(item);
                    WriteHistoryToFile($"Removed '{item.Product.Name}'");
                }
                else
                {
                    Console.WriteLine("Product not found in cart");
                }
            }

            public void UpdateProductQuantity(int productID, int newQuantity)
            {
                var item = cartItems.FirstOrDefault(p => p.Product.Id == productID);
                if (item != null)
                {
                    item.Quantity = newQuantity;
                    WriteHistoryToFile($"Updated quantity of '{item.Product.Name}'to {newQuantity}");
                }
                else
                {
                    Console.WriteLine("Product not found in cart! First add the product to the list.");
                }
            }

            public void WriteHistoryToFile(string message)
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine($"{DateTime.Now}: {message}");
                }
            }
        }
    }
}
