using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadMedixCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser(AddUserDto dto)
        {
            var result = await _authService.AddUserAsync(dto);
            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            //var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            //var userAgent = Request.Headers["User-Agent"].ToString();

            var token = await _authService.LoginAsync(dto);
            return Ok(new { token });
        }
    }
}
