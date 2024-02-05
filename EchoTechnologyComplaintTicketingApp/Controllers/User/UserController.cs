using EchoTechnologyComplaintTicketingApp.DTOS.User;
using EchoTechnologyComplaintTicketingApp.Services.Repository.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserById(UserDto userDto)
        {
            var user = await _userService.GetUserByIdAsync(userDto);
            return Ok(user);
        }
       // [Authorize(Policy = "RequireAdminPrivilege")]

        [HttpPost("/AllUsers")]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

    }

}
