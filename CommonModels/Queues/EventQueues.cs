using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels.Queues
{
    public class EventQueues
    {
        public static Dictionary<string, string> EventQueuePairs = new Dictionary<string, string>
        {
            ["OrderCreatedEvent"] = @"order-created",
            ["OrderStatusChangedEvent"] = @"order-status-change",
            ["NewTransactionEvent"] = @"new-transaction",
            ["PaymentStatusChangedEvent"] = @"payment-status-change"
        };
    }
}
