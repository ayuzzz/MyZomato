﻿using CommonModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Application.ServiceBus.Abstractions
{
    public interface IPaymentStatusChangedEventService
    {
        Task PublishThroughEventBus(PaymentStatusChangedEvent @event);
    }
}
