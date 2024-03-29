﻿using CommonModels;
using CommonModels.Enums;
using CommonModels.Events;
using Examples.SmtpExamples.Async;
using MassTransit;
using orderscommand.Services.Abstractions;
using orderscommand.Utility.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Application.EventHandlers
{
    public class OrderStatusChangedEventHandler : IConsumer<OrderStatusChangedEvent>
    {
        private readonly IOrderService _orderService;
        private readonly IEmailHelper _emailHelper;

        public OrderStatusChangedEventHandler(IOrderService orderService, IEmailHelper emailHelper)
        {
            _orderService = orderService;
            _emailHelper = emailHelper;
        }

        public async Task Consume(ConsumeContext<OrderStatusChangedEvent> context)
        {
            Guid transactionId = context.Message.Id;
            var (order, paymentStatus) = await _orderService.GetOrderDetailsAsync(transactionId);

            var initialOrderStatus = (int)order.Status;

            if(paymentStatus == (int)PaymentStatus.InProgress)
            {
                if (initialOrderStatus == (int)OrderStatus.Ordered)
                {
                    order.Status = (int)OrderStatus.FoodIsBeingPrepared;
                }
            }
            else if(paymentStatus == (int)PaymentStatus.Completed)
            {
                if (initialOrderStatus == (int)OrderStatus.Ordered)
                {
                    order.Status = (int)OrderStatus.FoodIsBeingPrepared;
                }
                else if (initialOrderStatus == (int)OrderStatus.FoodIsBeingPrepared)
                {
                    order.Status = (int)OrderStatus.OutForDelivery;
                }
                else if (initialOrderStatus == (int)OrderStatus.OutForDelivery)
                {
                    order.Status = (int)OrderStatus.Delivered;
                }
            }
            else if(paymentStatus == (int)PaymentStatus.Failed)
            {
                order.Status = (int)OrderStatus.Cancelled;
            }

            await _orderService.UpdateOrderStatusAsync(order);
            if(order.Status == (int)OrderStatus.FoodIsBeingPrepared)
            {
                var email = await _emailHelper.CreateMailWrapper(transactionId, (int)EmailType.FoodIsBeingPrepared);
                EmailUtility.SendMail(email);
            }
            if (order.Status == (int)OrderStatus.OutForDelivery)
            {
                var email = await _emailHelper.CreateMailWrapper(transactionId, (int)EmailType.OutForDelivery);
                EmailUtility.SendMail(email);
            }
            if (order.Status == (int)OrderStatus.Delivered)
            {
                var email = await _emailHelper.CreateMailWrapper(transactionId, (int)EmailType.Delivered);
                EmailUtility.SendMail(email);
            }
            if (order.Status == (int)OrderStatus.Cancelled)
            {
                var email = await _emailHelper.CreateMailWrapper(transactionId, (int)EmailType.OrderCancelled);
                EmailUtility.SendMail(email);
            }
        }
    }
}
