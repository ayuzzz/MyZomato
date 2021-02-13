using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<bool> CreateNewOrderAsync(Order order);
        Task<(Order, int)> GetOrderDetails(Guid transactionId);
        Task<bool> UpdateOrderStatus(Order order);
        Task<FullOrderDetails> GetFullOrderDetails(Guid transactionId);
    }
}
