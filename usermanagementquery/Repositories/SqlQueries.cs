using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace usermanagementquery.Repositories
{
    public static class SqlQueries
    {
        internal const string GetUserDetails = @"select u.Id as UserId, u.Name, u.Email, u.ContactNumber, uw.Balance as WalletBalance
                                                from [User] u inner join UserWallet uw on uw.UserId = u.Id";
    }
}
