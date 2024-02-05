using AutoMapper;
using EchoTechnologyComplaintTicketingApp.DTOS.User;
using EchoTechnologyComplaintTicketingApp.Models.Generic;
using EchoTechnologyComplaintTicketingApp.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Services.Repository.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<UserModel> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.UserId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<Page<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<Page<UserDto>>(users);
        }

    }

}
