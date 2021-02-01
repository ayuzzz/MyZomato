using CommonModels.Events;
using MassTransit;
using orderPaymentProcessingCommand.Application.ServiceBus.Abstractions;
using orderPaymentProcessingCommand.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Application.EventHandlers
{
    public class NewTransactionEventHandler : IConsumer<NewTransactionEvent>
    {
        private readonly ITransactionService _transactionService;
        private readonly IOrderStatusChangedEventService _orderStatusChangedEventService;
        private readonly IPaymentStatusChangedEventService _paymentStatusChangedEventService;

        public NewTransactionEventHandler(ITransactionService transactionService, IOrderStatusChangedEventService orderStatusChangedEventService,
            IPaymentStatusChangedEventService paymentStatusChangedEventService)
        {
            _transactionService = transactionService;
            _orderStatusChangedEventService = orderStatusChangedEventService;
            _paymentStatusChangedEventService = paymentStatusChangedEventService;
        }

        public async Task Consume(ConsumeContext<NewTransactionEvent> context)
        {
            Guid transactionId = context.Message.Id;
            OrderStatusChangedEvent orderStatusChangedEvent = new OrderStatusChangedEvent();
            orderStatusChangedEvent.Id = transactionId;

            PaymentStatusChangedEvent paymentStatusChangedEvent = new PaymentStatusChangedEvent();
            paymentStatusChangedEvent.Id = transactionId;

            if(await _transactionService.CreateNewTransactionAsync(transactionId))
            {
                Thread.Sleep(10000);
                await _orderStatusChangedEventService.PublishThroughEventBus(orderStatusChangedEvent);
                Thread.Sleep(10000);
                await _paymentStatusChangedEventService.PublishThroughEventBus(paymentStatusChangedEvent);
                Thread.Sleep(10000);
                await _orderStatusChangedEventService.PublishThroughEventBus(orderStatusChangedEvent);
                Thread.Sleep(10000);
                await _orderStatusChangedEventService.PublishThroughEventBus(orderStatusChangedEvent);
            }
        }
    }
}
