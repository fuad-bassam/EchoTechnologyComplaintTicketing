using EchoTechnologyComplaintTicketingApp.DTOS.User;
using EchoTechnologyComplaintTicketingApp.Models.Generic;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Services.Repository.User
{
    public interface IUserService
    {
        Task<Page<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(UserDto userDto);
    }
}