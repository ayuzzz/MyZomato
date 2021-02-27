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

        public async Task<(string, int)> FoodBeingPreparedMailBody(Guid transactionId)
        {
            var orderDetails = await _orderRepository.GetFullOrderDetails(transactionId);

            string body = @$"<html><body>
                            <h5>Woo Hoo...</h5>
                            <h5>Your food is being prepared {orderDetails.User.Split(" ")[0]}</h5><br>
                            <h5>Unique Transaction Id : {transactionId}</h5>
                            <h5>Amount : Rs. {orderDetails.OrderAmount}</h5>
                            <h5>Date of Order : {orderDetails.CreatedDate.ToShortTimeString()}</h5>
                            </body></html>
                            ";

            return (body, orderDetails.OrderId);
        }

        public async Task<(string, int)> OutForDeliveryMailBody(Guid transactionId)
        {
            var orderDetails = await _orderRepository.GetFullOrderDetails(transactionId);

            string body = @$"<html><body>
                            <h5>Yay !!</h5>
                            <h5>Your food is out for delivery {orderDetails.User.Split(" ")[0]}</h5><br>
                            <h5>Unique Transaction Id : {transactionId}</h5>
                            <h5>Amount : Rs. {orderDetails.OrderAmount}</h5>
                            <h5>Date of Order : {orderDetails.CreatedDate.ToShortTimeString()}</h5>
                            </body></html>
                            ";

            return (body, orderDetails.OrderId);
        }

        public async Task<(string, int)> FoodDeliveredMailBody(Guid transactionId)
        {
            var orderDetails = await _orderRepository.GetFullOrderDetails(transactionId);

            string body = @$"<html><body>
                            <h5>Woo Hoo...</h5>
                            <h5>Your food has been safely delivered {orderDetails.User.Split(" ")[0]}</h5><br>
                            <h5>Unique Transaction Id : {transactionId}</h5>
                            <h5>Amount : Rs. {orderDetails.OrderAmount}</h5>
                            <h5>Date of Order : {orderDetails.CreatedDate.ToShortTimeString()}</h5>
                            </body></html>
                            ";

            return (body, orderDetails.OrderId);
        }

        public async Task<(string, int)> OrderCancelledMailBody(Guid transactionId)
        {
            var orderDetails = await _orderRepository.GetFullOrderDetails(transactionId);

            string body = @$"<html><body>
                            <h5>OH NO...</h5>
                            <h5>Your order has been cancelled... Please try ordering again {orderDetails.User.Split(" ")[0]}</h5><br>
                            <h5>Unique Transaction Id : {transactionId}</h5>
                            <h5>Amount : Rs. {orderDetails.OrderAmount}</h5>
                            <h5>Date of Order : {orderDetails.CreatedDate.ToShortTimeString()}</h5>
                            </body></html>
                            ";

            return (body, orderDetails.OrderId);
        }

        public async Task<Email> CreateMailWrapper(Guid transactionId, int emailType)
        {
            Email email = new Email();
            email.ToAddress = "joshiayush2426@gmail.com";

            if(emailType == (int)EmailType.OrderCreated)
            {
                email.Subject = "New Order Created";
                email.MessageBody = await OrderCreatedMailBody(transactionId);
            }
            else if (emailType == (int)EmailType.FoodIsBeingPrepared)
            {
                var response = await FoodBeingPreparedMailBody(transactionId);
                email.MessageBody = response.Item1;
                email.Subject = $"Food is Being Prepared - Order Id : {response.Item2}";
            }
            else if (emailType == (int)EmailType.OutForDelivery)
            {
                var response = await OutForDeliveryMailBody(transactionId);
                email.MessageBody = response.Item1;
                email.Subject = $"Out For Delivery - Order Id : {response.Item2}";
            }
            else if (emailType == (int)EmailType.Delivered)
            {
                var response = await FoodDeliveredMailBody(transactionId);
                email.MessageBody = response.Item1;
                email.Subject = $"Food has been delivered - Order Id : {response.Item2}";
            }
            else if (emailType == (int)EmailType.OrderCancelled)
            {
                var response = await OrderCancelledMailBody(transactionId);
                email.MessageBody = response.Item1;
                email.Subject = $"Order Cancelled - Order Id : {response.Item2}";
            }

            return email;
        }
    }
}
