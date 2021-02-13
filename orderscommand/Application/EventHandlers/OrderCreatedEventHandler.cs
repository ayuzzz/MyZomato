using CommonModels.Events;
using Examples.SmtpExamples.Async;
using MassTransit;
using orderscommand.Application.ServiceBus.Abstractions;
using orderscommand.Utility.Abstractions;
using System.Diagnostics;
using System.Threading.Tasks;

namespace orderscommand.Application.EventHandlers
{
    public class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
    {
        private readonly INewTransactionEventService _newTransactionEventService;
        private readonly IEmailHelper _emailHelper;

        public OrderCreatedEventHandler(INewTransactionEventService newTransactionEventService, IEmailHelper emailHelper)
        {
            _newTransactionEventService = newTransactionEventService;
            _emailHelper = emailHelper;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var transactionId = context.Message.Id;

            NewTransactionEvent newTransactionEvent = new NewTransactionEvent();
            newTransactionEvent.Id = transactionId;

            var email = await _emailHelper.CreateMailWrapper(transactionId);
            EmailUtility.SendMail(email);

            await _newTransactionEventService.PublishThroughEventBus(newTransactionEvent);
        }
    }
}
