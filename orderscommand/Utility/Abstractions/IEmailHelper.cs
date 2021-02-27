using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderscommand.Utility.Abstractions
{
    public interface IEmailHelper
    {
        Task<string> OrderCreatedMailBody(Guid transactionId);
        Task<Email> CreateMailWrapper(Guid transactionId, int emailType);
    }
}
