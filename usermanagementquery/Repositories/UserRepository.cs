using CommonModels;
using CommonUtilities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usermanagementquery.Repositories.Abstraction;

namespace usermanagementquery.Repositories
{
    public class UserRepository:IUserRepository
    {
        private ISqlRepository _sqlRepository;

        public UserRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public async Task<List<UserDetails>> GetUserDetails()
        {
            try
            {
                IEnumerable<UserDetails> userDetails = await _sqlRepository.QueryAsync<UserDetails>(SqlQueries.GetUserDetails, commandTimeOut: 300);

                return userDetails.ToList();
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
