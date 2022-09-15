using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            var created = await _orderRepository.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _orderRepository.FindAll()
                            .OrderBy(u => u.Id)
                                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.FindByCondition(u => u.Id.Equals(orderId))
                            .SingleOrDefaultAsync();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            _orderRepository.Update(order);

            var updated = await _orderRepository.SaveChangesAsyncWithResult();

            return updated > 0;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var user = await GetOrderByIdAsync(orderId);

            if (user == null)
                return false;

            _orderRepository.RemoveById(orderId);

            var deleted = await _orderRepository.SaveChangesAsyncWithResult();

            return deleted > 0;
        }
    }
}
