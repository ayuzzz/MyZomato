using CommonUtilities.ServiceBus;
using CommonUtilities.ServiceBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Application.ServiceBus
{
    public class OrderCreatedEventBus
    {
        private readonly IEventBus _eventbus;

        public OrderCreatedEventBus(IEventBus eventbus)
        {
            _eventbus = eventbus;
        }

        public void Subscribe()
        {
            
        }
    }
}
