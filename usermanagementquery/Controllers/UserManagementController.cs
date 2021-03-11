using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usermanagementquery.Services.Abstraction;

namespace usermanagementquery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("user-details")]
        public async Task<IActionResult> GetUserDetails(int userId)
        {
            if(userId < 0)
            {
                return BadRequest("Invalid user id");
            }
            else
            {
                return Ok(await _userService.GetUserDetailsAsync(userId));
            }                
        }
    }
}