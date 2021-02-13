using CommonModels;
using CommonModels.Events;
using orderscommand.Application.ServiceBus.Abstractions;
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
        private readonly IOrderCreatedEventService _orderCreatedService;

        public OrderService(IOrderRepository orderRepository, IOrderCreatedEventService orderCreatedEventService)
        {
            _orderRepository = orderRepository;
            _orderCreatedService = orderCreatedEventService;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            OrderCreatedEvent orderCreatedEvent = new OrderCreatedEvent();
            orderCreatedEvent.Id = order.TransactionId ?? Guid.NewGuid();

            foreach(var orderProduct in order.OrderProducts)
            {
                order.OrderAmount += orderProduct.Price;
            }

            var result = await _orderRepository.CreateNewOrderAsync(order);
            if(result)
            {         
                await _orderCreatedService.PublishThroughEventBus(orderCreatedEvent);
            }

            return result;
        }

        public async Task<(Order, int)> GetOrderDetailsAsync(Guid transactionId)
        {
            return await _orderRepository.GetOrderDetails(transactionId);
        }

        public async Task<bool> UpdateOrderStatusAsync(Order order)
        {
            return await _orderRepository.UpdateOrderStatus(order);
        }
    }
}
