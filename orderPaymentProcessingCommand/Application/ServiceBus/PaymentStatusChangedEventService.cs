using CommonModels.Events;
using CommonUtilities.ServiceBus.Abstractions;
using orderPaymentProcessingCommand.Application.ServiceBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Application.ServiceBus
{
    public class PaymentStatusChangedEventService : IPaymentStatusChangedEventService
    {
        private readonly IEventService _eventService;

        public PaymentStatusChangedEventService(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task PublishThroughEventBus(PaymentStatusChangedEvent @event)
        {
            var queueEndpoint = await _eventService.GetEndpointForEventBusAsync(@event);
            await queueEndpoint.Send<PaymentStatusChangedEvent>(@event);
        }
    }
}
