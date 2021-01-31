using CommonModels.Events;
using CommonUtilities.ServiceBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquery.Application.ServiceBus.Abstractions
{
    public interface IOrderCreatedService
    {
        Task PublishThroughEventBus(OrderCreatedEvent @event);
    }
}
