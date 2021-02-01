using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Services.Abstractions
{
    public interface ITransactionService
    {
        Task<bool> CreateNewTransactionAsync(Guid transactionId);
        Task<(int, int)> GetPaymentDetailsAsync(Guid transactionId);
        Task<bool> UpdatePaymentStatusAsync(Guid transactionId, int walletBalance);
    }
}
