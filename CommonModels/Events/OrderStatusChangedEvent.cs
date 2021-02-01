using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels.Events
{
    public class OrderStatusChangedEvent:IntegrationEvent
    {
        public OrderStatusChangedEvent() : base()
        {
            EventName = "OrderStatusChangedEvent";
        }
    }
}
