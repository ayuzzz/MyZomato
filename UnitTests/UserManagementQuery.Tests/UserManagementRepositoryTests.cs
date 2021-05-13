using CommonModels;
using CommonUtilities.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using usermanagementquery.Repositories;
using usermanagementquery.Repositories.Abstraction;
using usermanagementquery.Services;
using usermanagementquery.Services.Abstraction;
using Xunit;

namespace UserManagementQuery.Tests
{
    public class UserManagementRepositoryTests
    {
        private Mock<ISqlRepository> _sqlRepo;
        private UserRepository _userRepo;

        public UserManagementRepositoryTests()
        {
            _sqlRepo = new Mock<ISqlRepository>();
            _sqlRepo.Setup(sql => sql.QueryAsync<UserDetails>(It.IsAny<string>(), null, It.IsAny<CommandType>(), It.IsAny<int>()))
                    .ReturnsAsync(MockDataStore.GetUserDetails());
            _userRepo = new UserRepository(_sqlRepo.Object);
        }

        [Fact]
        public async Task ToValidate_UserDetails_ValidOutput()
        {
            var response = await _userRepo.GetUserDetails();

            Assert.NotNull(response);
        }
    }
}
