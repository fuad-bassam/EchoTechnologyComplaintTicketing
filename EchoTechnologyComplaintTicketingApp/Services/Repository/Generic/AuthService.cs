using EchoTechnologyComplaintTicketingApp.DTOS.User;
using EchoTechnologyComplaintTicketingApp.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EchoTechnologyComplaintTicketingApp.Services.Repository.Generic
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IConfiguration configuration, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> SignUp(UserSignupDto userSignupDto)
        {
            try
            {
                var user = new UserModel { UserName = userSignupDto.Email, Email = userSignupDto.Email, NameAr = userSignupDto.NameAr, NameEn = userSignupDto.NameEn, PhoneNumber = userSignupDto.PhoneNumber };
                var result = await _userManager.CreateAsync(user, userSignupDto.Password);

                if (result.Succeeded)
                {
                    return await Login(new UserLoginDto { Email = userSignupDto.Email, Password = userSignupDto.Password });
                }

                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> Login(UserLoginDto loginDto)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(loginDto.Email);

                    if (user != null && user.IsAdminPrivilege)
                    {
                        await _userManager.AddClaimAsync(user, new Claim("IsAdminPrivilege", "true"));
                    }

                    var tokenService = new JwtTokenService(_configuration);
                    return tokenService.GenerateToken(loginDto.Email);
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
