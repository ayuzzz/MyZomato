using CommonModels;
using orderscommand.Repositories.Abstractions;
using orderscommand.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            return await _orderRepository.CreateNewOrderAsync(order);
        }
    }
}
