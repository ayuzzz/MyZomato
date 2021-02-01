using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Repositories
{
    public static class SqlQueries
    {
        internal const string CreateOrder = @"insert into [order]([Status], TransactionId, RestaurantId, OrderAmount, UserId, CreatedDate) values
                                              (@status, @transactionId, @restaurantId, @orderAmount, @userId, GETDATE())";

        internal const string GetOrderDetails = @"select Id, Status, TransactionId, RestaurantId, UserId, CreatedDate, ModifiedDate from [Order]
                                                    where TransactionId = @transactionId

                                                  select PaymentStatus from [Transaction] where Id = @transactionId";

        internal const string UpdateOrderStatus = @"update [Order] set Status = @status where Id = @orderId";
    }
}
