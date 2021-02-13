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

        internal const string UpdateTransactionStatus = @"Declare @userId int = (select UserId from [Order] where TransactionId = @transactionId);
                                                            Declare @orderAmount int = (select OrderAmount from [Order] where UserId = @userId and TransactionId = @transactionId);


                                                            update [Transaction] set PaymentStatus =
                                                            (
                                                            select
                                                            CASE
	                                                            WHEN (PaymentStatus = 1 and (@walletBalance >= @orderAmount)) or PaymentStatus = 3 THEN 3
	                                                            WHEN (PaymentStatus = 1 and (@walletBalance < @orderAmount)) or PaymentStatus = 2 THEN 2
                                                            END), ModifiedDate = GETDATE()
                                                            where Id = @transactionId

                                                            Declare @paymentStatus int = (select PaymentStatus from [Transaction] where Id = @transactionId)

                                                            update [UserWallet] set Balance = 
                                                            CASE
	                                                            WHEN @paymentStatus = 3 AND @orderAmount <= @walletBalance THEN Balance - @orderAmount
	                                                            ELSE Balance
                                                            END
                                                            where UserId = @userId";
    }
}
