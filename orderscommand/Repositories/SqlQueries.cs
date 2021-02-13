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

        internal const string UpdateOrderStatus = @"update [Order] set Status = @status, ModifiedDate = GETDATE() where Id = @orderId";

        internal const string GetDetailsForMail = @"select 
                                                    o.Id as OrderId, os.Status as OrderStatus, o.OrderAmount,
                                                    o.RestaurantId, r.Name as Restaurant,
                                                    o.UserId, u.Name as [User],
                                                    o.CreatedDate, o.ModifiedDate
                                                    from [Order] o
                                                    inner join Restaurants r on r.Id = o.RestaurantId
                                                    inner join OrderStatus os on os.Id = o.Status
                                                    inner join [User] u on u.Id = o.UserId
                                                    where o.TransactionId = @transactionId";
    }
}
