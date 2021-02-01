using CommonModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Application.ServiceBus.Abstractions
{
    public interface IOrderCreatedEventService
    {
        Task PublishThroughEventBus(OrderCreatedEvent @event);
    }
}
