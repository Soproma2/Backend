using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Services.Order
{
    internal interface IOrderService
    {
        void Checkout(Models.User user);
        void ViewOrderHistory(Models.User user);
        void CancelOrder(Models.User user);
        void ViewAllOrders();
        void MarkOrderDelivered();
        void AdminCancelOrder();
        void ViewOrderDetails();
    }
}
