using EchoTechnologyComplaintTicketingApp.DTOS.User;
using EchoTechnologyComplaintTicketingApp.Models.User;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Services.Repository.Generic
{
    public interface IAuthService
    {
        Task<string> Login(UserLoginDto loginDto);
        Task Logout();
        Task<string> SignUp(UserSignupDto userSignupDto);
    }
}