using CommonModels.Events;
using CommonUtilities.ServiceBus.Abstractions;
using orderscommand.Application.ServiceBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Application.ServiceBus
{
    public class NewTransactionEventService : INewTransactionEventService
    {
        private readonly IEventService _eventService;

        public NewTransactionEventService(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task PublishThroughEventBus(NewTransactionEvent @event)
        {
            var queueEndpoint = await _eventService.GetEndpointForEventBusAsync(@event);
            await queueEndpoint.Send<NewTransactionEvent>(@event);
        }
    }
}
