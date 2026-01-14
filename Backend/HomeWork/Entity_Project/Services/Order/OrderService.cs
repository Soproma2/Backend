using Entity_Project.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Order
{
    internal class OrderService : IOrderService
    {
        private readonly DataContext _db = new DataContext();
        public void Checkout(Models.User user)
        {
            if (user == null) throw new Exception("Unauthorized!");

            var cartItems = _db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == user.Id)
                .ToList();

            if (!cartItems.Any()) throw new Exception("Your cart is empty!");

            double totalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity);

            var dbUser = _db.Users.Find(user.Id);
            if (dbUser.Balance < totalPrice)
                throw new Exception($"Insufficient balance! Needed: {totalPrice}$, Available: {dbUser.Balance}$");

            foreach ( var item in cartItems)
            {
                if(item.Product.Stock < item.Quantity)
                    throw new Exception($"Product {item.Product.Name}. Insufficient quantity in stock | Stock: {item.Product.Stock}");
            }

            Models.Order order = new Models.Order()
            {
                UserId = user.Id,
                TotalPrice = totalPrice,
                Status = Enums.OrderStatus.PENDING,
                Items = cartItems.Select(c => new Models.OrderItem
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Product.Price
                }).ToList()
            };

            dbUser.Balance -= totalPrice;
            user.Balance = dbUser.Balance;

            foreach ( var item in cartItems)
            {
                item.Product.Stock -= item.Quantity;
            }

            _db.CartItems.RemoveRange(cartItems);
            _db.SaveChanges();
            Console.WriteLine($"Order placed successfully! Total spent: {totalPrice}$");
        }
        public void ViewOrderHistory(Models.User user)
        {
            throw new NotImplementedException();
        }
        public void CancelOrder(Models.User user)
        {
            throw new NotImplementedException();
        }

        public void AdminCancelOrder()
        {
            throw new NotImplementedException();
        }


        public void MarkOrderDelivered()
        {
            throw new NotImplementedException();
        }

        public void ViewAllOrders()
        {
            throw new NotImplementedException();
        }

        public void ViewOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

    }
}
