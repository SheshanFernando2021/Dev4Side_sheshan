using Dev4Side_sheshan.DTOs;
using Dev4Side_sheshan.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dev4Side_sheshan.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            await _authService.RegisterAsync(userRegisterDTO);
            return Ok(new {message = $"User {userRegisterDTO.Email} : Registration successful 🎉"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var token = await _authService.LoginAsync(userLoginDTO);
            return Ok(new AuthResponse { Token = token });
        }
    }
}
