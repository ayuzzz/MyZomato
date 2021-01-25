using CommonModels;
using CommonModels.Queues;
using CommonUtilities.ServiceBus.Abstractions;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.ServiceBus
{
    public class ServicebusConnectionFactory : IServicebusConnectionFactory
    {
        private const string _userName = "guest";
        private const string _password = "guest";
        private const string _virtualHost = "/";
        private const string _hostName = "localhost";

        public Task<string> GetServicebusEndpointUrl<TEvent>(TEvent @event)
        {
            var type = @event.GetType().Name;
            return Task.FromResult($"rabbitmq://{_hostName}/{EventQueues.EventQueuePairs[type]}");
        }

        public static Task SetServicebusConnectionProperties(IConfiguration configuration)
        {
            configuration["ServiceBus:Username"] = _userName;
            configuration["ServiceBus:Password"] = _password;
            configuration["ServiceBus:VirtualHost"] = _virtualHost;
            configuration["ServiceBus:Hostname"] = _hostName;

            return Task.FromResult(0);
        }
    }
}
