using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Repositories.Abstractions
{
    public interface ITransactionRepository
    {
        Task<bool> CreateNewTransaction(Guid transactionId);
        Task<(int, int)> GetPaymentDetails(Guid transactionId);
        Task<bool> UpdateTransactionStatus(Guid transactionId, int walletBalance);
    }
}
