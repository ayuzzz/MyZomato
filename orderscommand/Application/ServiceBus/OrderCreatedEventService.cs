using CommonModels.Events;
using CommonUtilities.ServiceBus.Abstractions;
using orderscommand.Application.ServiceBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Application.ServiceBus
{
    public class OrderCreatedEventService : IOrderCreatedEventService
    {
        private readonly IEventService _eventService;

        public OrderCreatedEventService(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task PublishThroughEventBus(OrderCreatedEvent @event)
        {
            var queueEndpoint = await _eventService.GetEndpointForEventBusAsync(@event);
            await queueEndpoint.Send<OrderCreatedEvent>(@event);
        }
    }
}
