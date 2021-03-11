using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace usermanagementquery.Repositories.Abstraction
{
    public interface IUserRepository
    {
        Task<List<UserDetails>> GetUserDetails();
    }
}
