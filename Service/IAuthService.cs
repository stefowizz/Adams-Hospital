using AdamsHospitalAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace AdamsHospitalAPI.Service
{
    public interface IAuthService
    {
        Task<bool> LoginUser(Registration RegUser);
        Task<IdentityResult> RegisterUser(Registration RegUser);
    }
}
