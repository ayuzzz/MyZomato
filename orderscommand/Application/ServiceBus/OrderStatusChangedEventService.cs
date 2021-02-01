using CommonModels.Events;
using CommonUtilities.ServiceBus.Abstractions;
using orderscommand.Application.ServiceBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Application.ServiceBus
{
    public class OrderStatusChangedEventService : IOrderStatusChangedService
    {
        private readonly IEventService _eventService;
        public OrderStatusChangedEventService(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task PublishThroughEventBus(OrderStatusChangedEvent @event)
        {
            var queueEndpoint = await _eventService.GetEndpointForEventBusAsync(@event);
            await queueEndpoint.Send<OrderStatusChangedEvent>(@event);
        }
    }
}
