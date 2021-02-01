using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels.Events
{
    public class PaymentStatusChangedEvent : IntegrationEvent
    {
        public PaymentStatusChangedEvent() : base()
        {
            EventName = "PaymentStatusChangedEvent";
        }
    }
}
