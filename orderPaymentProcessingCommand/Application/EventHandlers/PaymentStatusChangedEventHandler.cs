using CommonModels.Enums;
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
    public class PaymentStatusChangedEventHandler : IConsumer<PaymentStatusChangedEvent>
    {
        private readonly ITransactionService _transactionService;

        public PaymentStatusChangedEventHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task Consume(ConsumeContext<PaymentStatusChangedEvent> context)
        {
            Guid transactionId = context.Message.Id;
            var (paymentStatus, walletBalance) = await _transactionService.GetPaymentDetailsAsync(transactionId);

            if(paymentStatus != (int)PaymentStatus.Completed && paymentStatus != (int)PaymentStatus.Failed)
            {
                await _transactionService.UpdatePaymentStatusAsync(transactionId, walletBalance);
            }            
        }
    }
}
