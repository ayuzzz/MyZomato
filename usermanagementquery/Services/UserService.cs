using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usermanagementquery.Repositories.Abstraction;
using usermanagementquery.Services.Abstraction;

namespace usermanagementquery.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDetails>> GetUserDetailsAsync(int userId)
        {
            List<UserDetails> userDetails = await _userRepository.GetUserDetails();
            List<UserDetails> userDetailsList = new List<UserDetails>();

            if(userId == 0)
            {
                userDetailsList = userDetails;
            }
            else
            {
                userDetailsList = userDetails.Where(u => u.UserId == userId).ToList();
            }

            return userDetailsList;
        }
    }
}
