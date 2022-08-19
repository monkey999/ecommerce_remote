using Domain;
using System.Collections.Generic;

namespace Logic.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetOrders();
    }
}