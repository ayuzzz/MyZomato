using CommonModels;
using CommonModels.Enums;
using orderscommand.Repositories.Abstractions;
using orderscommand.Utility.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Utility
{
    public class EmailHelper : IEmailHelper
    {
        private readonly IOrderRepository _orderRepository;

        public EmailHelper(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> OrderCreatedMailBody(Guid transactionId)
        {
            var orderDetails = await _orderRepository.GetFullOrderDetails(transactionId);

            string body = @$"<html><body>
                            <h5>Order For : {orderDetails.User}</h5>
                            <h5>Order Id : {orderDetails.OrderId}</h5>
                            <h5>Unique Transaction Id : {transactionId}</h5>
                            <h5>Amount : Rs. {orderDetails.OrderAmount}</h5>
                            <h5>Restaurant : {orderDetails.Restaurant}</h5>
                            <h5>Date of Order : {orderDetails.CreatedDate.ToShortTimeString()}</h5>
                            </body></html>
                            ";

            return body;
        }

        public async Task<Email> CreateMailWrapper(Guid transactionId, int emailType)
        {
            Email email = new Email();
            email.Subject = "New Order Created";
            email.ToAddress = "joshiayush2426@gmail.com";

            if(emailType == (int)EmailType.OrderCreated)
            {
                email.MessageBody = await OrderCreatedMailBody(transactionId);
            }

            return email;
        }
    }
}
