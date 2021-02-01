using CommonModels.Events;
using MassTransit;
using orderscommand.Application.ServiceBus.Abstractions;
using System.Diagnostics;
using System.Threading.Tasks;

namespace orderscommand.Application.EventHandlers
{
    public class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
    {
        private readonly INewTransactionEventService _newTransactionEventService;

        public OrderCreatedEventHandler(INewTransactionEventService newTransactionEventService)
        {
            _newTransactionEventService = newTransactionEventService;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var transactionId = context.Message.Id;

            NewTransactionEvent newTransactionEvent = new NewTransactionEvent();
            newTransactionEvent.Id = transactionId;

            await _newTransactionEventService.PublishThroughEventBus(newTransactionEvent);
        }
    }
}
