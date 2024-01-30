using AdamsHospitalAPI.Models;
using AdamsHospitalAPI.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AdamsHospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationAPIController : ControllerBase
    {
        IAuthService _authService; 
        public RegistrationAPIController(IAuthService authService)
        {
           _authService = authService;   
        }

        [HttpPost]
        [Route("register")] 
        public async Task<IActionResult> Register(Registration RegUser) 
        {
            var result = await _authService.RegisterUser(RegUser);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Registration RegUser)
        {
            var result = await _authService.LoginUser(RegUser);
            if(result == true)
            {
                return Ok(result);
            }
            else 
            { 
                return BadRequest(result); 
            } 
        }
    }
}  
