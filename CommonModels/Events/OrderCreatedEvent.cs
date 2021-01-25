using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonModels.Events
{
    public class OrderCreatedEvent:IntegrationEvent
    {
        public OrderCreatedEvent():base()
        {
            EventName = "OrderCreatedEvent";
        }
    }
}
