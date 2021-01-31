using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Services.Abstractions
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(Order order);
    }
}
