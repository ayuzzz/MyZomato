using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Repositories
{
    public static class SqlQueries
    {
        internal const string createNewTransaction = @"insert into [Transaction](Id, PaymentStatus, Mode, CreatedDate) values
                                                        (@transactionId, @paymentStatus, 'Wallet', GETDATE())";

        internal const string GetPaymentDetails = @"select PaymentStatus from [Transaction] where Id = @transactionId

                                                    select Balance from [UserWallet] where UserId = @userId";

        internal const string UpdateTransactionStatus = @"Declare @userId int = (select UserId from [Order] where TransactionId = @transactionid)
                                                        Declare @orderAmount int = (select OrderAmount from [Order] where UserId = @userId and TransactionId = @transactionid)

                                                        update [Transaction] set PaymentStatus =
                                                        (CASE
	                                                        WHEN PaymentStatus = 1 and (@walletBalance >= @orderAmount) THEN 3
	                                                        ELSE 2
                                                        END)
                                                        where Id = @transactionId";
    }
}
