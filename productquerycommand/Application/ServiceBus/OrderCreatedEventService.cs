using CommonModels;
using CommonModels.Events;
using CommonUtilities.ServiceBus;
using CommonUtilities.ServiceBus.Abstractions;
using MassTransit;
using productquerycommand.Application.ServiceBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productquerycommand.Application.ServiceBus
{
    public class OrderCreatedEventService:IOrderCreatedService
    {
        private readonly IServicebusConnectionFactory _servicebusConnectionFactory;
        private readonly IBusControl _bus;
        private readonly IEventService _eventService;

        public OrderCreatedEventService(IServicebusConnectionFactory servicebusConnectionFactory, IBusControl bus, IEventService eventService)
        {
            _servicebusConnectionFactory = servicebusConnectionFactory;
            _bus = bus;
            _eventService = eventService;
        }

        public async Task PublishThroughEventBus(OrderCreatedEvent @event)
        {
            var queueEndpoint = await _eventService.PublishThroughEventBusAsync(@event);
            await queueEndpoint.Send<OrderCreatedEvent>(@event);
        }
    }
}
