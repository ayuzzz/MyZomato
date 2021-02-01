using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Repositories.Abstractions
{
    public interface ITransactionRepository
    {
        Task<bool> CreateNewTransaction(Guid transactionId);
        Task<int> GetPaymentDetails(Guid transactionId);
        Task<(int, int)> UpdateTransactionStatus(Guid transactionId, int walletBalance);
    }
}
