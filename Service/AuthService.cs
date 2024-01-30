using AdamsHospitalAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace AdamsHospitalAPI.Service
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _config = configuration;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(Registration RegUser) 
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = RegUser.UserName,
                Email = RegUser.Email,
            };
            var result = await _userManager.CreateAsync(user, RegUser.Password);
            return result; 
        }

        public async Task<bool> LoginUser(Registration RegUser)
        {
            var identityuser = await _userManager.FindByEmailAsync(RegUser.Email);
            if (identityuser != null)
            {
                if(await _userManager.CheckPasswordAsync(identityuser, RegUser.Password))
                {
                    return true;
                }
                return false; 
            }
            else
            {
                return false; 
            }
        }
    }
}
