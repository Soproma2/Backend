using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Cart
{
    internal interface ICartService
    {
        void AddToCart(Models.User user);
        void RemoveFromCart(Models.User user);
        void ViewCart(Models.User user);
        void UpdateCartQuantity(Models.User user);
        void ClearCart(Models.User user);
    }
}
