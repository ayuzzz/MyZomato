using Automatonymous;
using CommonModels;
using CommonUtilities.ServiceBus.Abstractions;
using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonUtilities.ServiceBus
{
    public class EventService : IEventService
    {
        private readonly IServicebusConnectionFactory _servicebusConnectionFactory;
        private readonly IBusControl _bus;

        public EventService(IServicebusConnectionFactory servicebusConnectionFactory, IBusControl bus)
        {
            _servicebusConnectionFactory = servicebusConnectionFactory;
            _bus = bus;
        }

        public async Task<ISendEndpoint> PublishThroughEventBusAsync(IntegrationEvent @event)
        {
            var queueEndpoint = await _bus.GetSendEndpoint(new Uri(await _servicebusConnectionFactory.GetServicebusEndpointUrl(@event)));
            return queueEndpoint;
        }

        public async Task<ISendEndpoint> GetEndpointForEventBusAsync(IntegrationEvent @event)
        {
            var queueEndpoint = await _bus.GetSendEndpoint(new Uri(await _servicebusConnectionFactory.GetServicebusEndpointUrl(@event)));
            return queueEndpoint;
        }
    }
}
