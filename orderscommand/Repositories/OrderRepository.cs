using CommonModels;
using CommonUtilities.Abstractions;
using Dapper;
using orderscommand.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
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

            int newResult = 0;

            if(result > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ProductId", typeof(int));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("Price", typeof(int));

                foreach(var product in order.OrderProducts)
                {
                    dt.Rows.Add(product.ProductId, product.Quantity, product.Price);
                }

                newResult = await _sqlRepository.ExecuteAsync(SqlQueries.InsertOrderProducts_sp, 
                    new
                    {
                        @transactionId = order.TransactionId,
                        @products = dt.AsTableValuedParameter("dbo.OrderProducts_Type")
                    }, commandType:CommandType.StoredProcedure);
            }

            return (newResult > 0);
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

        public async Task<FullOrderDetails> GetFullOrderDetails(Guid transactionId)
        {
            var orderDetails = await _sqlRepository.QueryAsync<FullOrderDetails>(SqlQueries.GetDetailsForMail, new { transactionId = transactionId });

            return orderDetails.FirstOrDefault();
        }
    }
}
