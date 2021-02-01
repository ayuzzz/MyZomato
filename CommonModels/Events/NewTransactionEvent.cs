using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels.Events
{
    public class NewTransactionEvent : IntegrationEvent
    {
        public NewTransactionEvent() : base()
        {
            EventName = "NewTransactionEvent";
        }
    }
}
