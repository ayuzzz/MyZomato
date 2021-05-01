using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using usermanagementquery.Controllers;
using usermanagementquery.Repositories.Abstraction;
using usermanagementquery.Services.Abstraction;
using Xunit;

namespace UserManagementQuery.Tests
{
    public class UserManagementControllerTests
    {
        private Mock<IUserRepository> _userRepo;
        private Mock<IUserService> _userService;
        private UserManagementController controller;

        public UserManagementControllerTests()
        {
            _userRepo = new Mock<IUserRepository>();
            _userRepo.Setup(r => r.GetUserDetails()).ReturnsAsync(MockDataStore.GetUserDetails());
            _userService = new Mock<IUserService>();

            controller = new UserManagementController(_userService.Object);
        }

        [Fact]
        public async Task ToValidate_GetUserDetails_InvalidInputsAsync()
        {
            int userId = 1;
            var response = await controller.GetUserDetails(userId);
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
