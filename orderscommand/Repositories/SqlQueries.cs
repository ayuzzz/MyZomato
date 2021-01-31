using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Repositories
{
    public static class SqlQueries
    {
        internal const string CreateOrder = @"insert into [order]([Status], TransactionId, RestaurantId, UserId, CreatedDate) values
                                              (@status, @transactionId, @restaurantId, @userId, GETDATE())";
    }
}
