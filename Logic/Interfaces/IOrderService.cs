using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<bool> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}