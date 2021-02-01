using CommonModels;
using CommonUtilities.Abstractions;
using orderscommand.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ISqlRepository _sqlRepository;

        public OrderRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<bool> CreateNewOrderAsync(Order order)
        {
            var result = await _sqlRepository.ExecuteAsync(SqlQueries.CreateOrder,
                            new
                            {
                                @status = order.Status,
                                @transactionId = order.TransactionId,
                                @restaurantId = order.RestaurantId,
                                //@userId = order.UserId
                                @userId = 1,
                                @orderAmount = order.OrderAmount
                            }
                        );

            return (result > 0);
        }

        public async Task<(Order, int)> GetOrderDetails(Guid transactionId)
        {
            var result = await _sqlRepository.QueryMultipleAsync<Order, int>(SqlQueries.GetOrderDetails,
                            new
                            {
                                @transactionId = transactionId                               
                            }
                        );

            return (result.Item1.FirstOrDefault(), result.Item2.FirstOrDefault());
        }

        public async Task<bool> UpdateOrderStatus(Order order)
        {
            var result = await _sqlRepository.ExecuteAsync(SqlQueries.UpdateOrderStatus,
                new 
                {
                    @status = order.Status,
                    @orderId = order.Id
                });

            return result > 0;
        }
    }
}
