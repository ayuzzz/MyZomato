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
                                @userId = 1
                            }
                        );

            return (result > 0);
        }
    }
}
