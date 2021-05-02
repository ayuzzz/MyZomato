using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using usermanagementquery.Repositories.Abstraction;
using usermanagementquery.Services;
using usermanagementquery.Services.Abstraction;
using Xunit;

namespace UserManagementQuery.Tests
{
    public class UserManagementServiceTests
    {
        private Mock<IUserRepository> _userRepo;
        private IUserService _userService;

        public UserManagementServiceTests()
        {
            _userRepo = new Mock<IUserRepository>();
            _userRepo.Setup(r => r.GetUserDetails()).ReturnsAsync(MockDataStore.GetUserDetails);

            _userService = new UserService(_userRepo.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task ToValidate_UserDetails_ValidOutput(int userId)
        {
            var response = await _userService.GetUserDetailsAsync(userId);

            Assert.NotNull(response);
        }
    }
}
