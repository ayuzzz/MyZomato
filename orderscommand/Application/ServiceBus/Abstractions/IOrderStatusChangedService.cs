using CommonModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Application.ServiceBus.Abstractions
{
    public interface IOrderStatusChangedService
    {
        Task PublishThroughEventBus(OrderStatusChangedEvent @event);
    }
}
