using CommonModels;
using CommonUtilities.ServiceBus.Abstractions;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.ServiceBus
{
    public class EventBus:IEventBus
    {
        private readonly IServicebusConnectionFactory _servicebusConnectionFactory;
        //private readonly IConfiguration _configuration;

        public EventBus(IServicebusConnectionFactory servicebusConnectionFactory, IConfiguration configuration)
        {
            _servicebusConnectionFactory = servicebusConnectionFactory;
        }

        //public async Task<IBusControl> Subscribe(string eventQueue, Type TEventHandler)
        //{
            
        //    //Not required as of now
        //    /*
        //    _channel = await _servicebusConnectionFactory.CreateConnection();
        //    _channel.QueueBind(queue:"Hello", exchange: "amq.direct", routingKey:"Hello", arguments:null);
        //    Debug.WriteLine($"is open : {_channel.IsOpen}, channel number : {_channel.ChannelNumber}, closereason : {_channel.CloseReason}");
        //    */
        //    return busControl;
        //}

        //public void Unsubscribe()
        //{
        //    _channel.QueueUnbind(queue: "Hello", exchange: "amq.direct", routingKey: "Hello", arguments: null);
        //}
    }
}
