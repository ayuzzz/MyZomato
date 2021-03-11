using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace usermanagementquery.Services.Abstraction
{
    public interface IUserService
    {
        Task<List<UserDetails>> GetUserDetailsAsync(int userId);
    }
}
