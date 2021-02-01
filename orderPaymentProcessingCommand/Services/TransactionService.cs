using CommonUtilities.Abstractions;
using orderPaymentProcessingCommand.Repositories.Abstractions;
using orderPaymentProcessingCommand.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderPaymentProcessingCommand.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<bool> CreateNewTransactionAsync(Guid transactionId)
        {
            return await _transactionRepository.CreateNewTransaction(transactionId);
        }

        public Task<int> GetPaymentDetailsAsync(Guid transactionId)
        {
            return _transactionRepository.GetPaymentDetails(transactionId);
        }

        public async Task<(int, int)> UpdatePaymentStatusAsync(Guid transactionId, int walletBalance)
        {
            return await _transactionRepository.UpdateTransactionStatus(transactionId, walletBalance);
        }
    }
}
