using CommonModels;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.ServiceBus.Abstractions
{
    public interface IServicebusConnectionFactory
    {
        Task<string> GetServicebusEndpointUrl<TEvent>(TEvent @event);
    }
}
