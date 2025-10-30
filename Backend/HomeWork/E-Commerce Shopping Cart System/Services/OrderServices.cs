using E_Commerce_Shopping_Cart_System.Enums;
using E_Commerce_Shopping_Cart_System.Models;
using E_Commerce_Shopping_Cart_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Shopping_Cart_System.Services
{
    public static class OrderServices
    {
        public static string path = "Data/Orders.json";
        public static List<Order> Orders = JsonHelper.LoadData<Order>(path);
        public static void Checkout(User user)
        {
            var cart = CartServices.CartItems.Where(c => c.User.Id == user.Id).ToList();
            if (cart.Count == 0) { Console.WriteLine("Cart empty!"); return; }

            double total = 0;
            foreach (var c in cart)
            {
                var p = ProductServices.Products.FirstOrDefault(x => x.Id == c.Product.Id);
                if (p != null) total += p.Price * c.Quantity;
            }

            if (user.Balance < total) { Console.WriteLine("Insufficient balance!"); return; }
            user.Balance -= total;
            JsonHelper.SaveData(UserServices.path, UserServices.Users);

            var order = new Order { User = user, TotalPrice = total };
            foreach(var c in cart)
            {
                var p = ProductServices.Products.FirstOrDefault(x => x.Id == c.Product.Id);
                if(p != null)
                {
                    order.Product = p;
                    order.Quantity = c.Quantity;
                    order.Status = OrderStatus.PENDING;
                    Orders.Add(new Order
                    {
                        User = user,
                        Product = p,
                        Quantity = c.Quantity,
                        TotalPrice = p.Price * c.Quantity,
                        Status = OrderStatus.PENDING,
                    });
                }
            }
            Orders.Add(order);
            JsonHelper.SaveData(path, Orders);
            JsonHelper.SaveData(ProductServices.path, ProductServices.Products);

            CartServices.CartItems.RemoveAll(c => c.User.Id == user.Id);
            JsonHelper.SaveData(CartServices.path, CartServices.CartItems);
            Console.WriteLine("Checkout successful!");
        }

        public static void ViewOrderHistory(User user)
        {
            var userOrders = Orders.Where(o => o.User.Id == user.Id).ToList();
            if (userOrders.Count == 0) { Console.WriteLine("No orders!"); return; }
            foreach (var o in userOrders)
            {
                Console.WriteLine($"Order #{o.Id} - {o.CreatedAt} - Total: {o.TotalPrice}₾ - Status: {o.Status}");
                var p = o.Product;
                if (p != null)
                {
                    Console.WriteLine($"  {p.Name} x {o.Quantity} = {p.Price * o.Quantity}₾");
                }
            }
        }

        public static void CancelOrder()
        {

        }

        public static void ViewAllOrders()
        {

        }
    }
}
