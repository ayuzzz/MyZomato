using CommonModels.Enums;
using CommonUtilities;
using CommonUtilities.Abstractions;
using orderPaymentProcessingCommand.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ISqlRepository _sqlRepository;

        public TransactionRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<bool> CreateNewTransaction(Guid transactionId)
        {
            var result = await _sqlRepository.ExecuteAsync(SqlQueries.createNewTransaction,
                
                new
                {
                    transactionId = transactionId,
                    paymentStatus = (int)PaymentStatus.InProgress
                });

            return result > 0;
        }

        public async Task<(int, int)> GetPaymentDetails(Guid transactionId)
        {
            var result = await _sqlRepository.QueryMultipleAsync<int, int>(SqlQueries.GetPaymentDetails,
                new
                {
                    transactionId = transactionId
                });

            return (result.Item1.FirstOrDefault(), result.Item2.FirstOrDefault());
        }

        public async Task<bool> UpdateTransactionStatus(Guid transactionId, int walletBalance)
        {
            var result = await _sqlRepository.ExecuteAsync(SqlQueries.UpdateTransactionStatus,
                new
                {
                    transactionId = transactionId,
                    walletBalance = walletBalance
                });

            return result > 0;
        }
    }
}
