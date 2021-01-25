using CommonModels.Events;
using MassTransit;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ordersquerycommand.Application.EventHandlers
{
    public class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
    {
        public OrderCreatedEventHandler()
        {

        }

        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            Debug.WriteLine($"{context.Message.Id}, {context.Message.EventName}");

            return Task.FromResult(0);
        }
    }
}
