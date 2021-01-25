using CommonModels;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.ServiceBus.Abstractions
{
    public interface IEventService
    {
        Task<ISendEndpoint> PublishThroughEventBusAsync(IntegrationEvent @event);
    }
}
