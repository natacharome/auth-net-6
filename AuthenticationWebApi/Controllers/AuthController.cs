using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWebApi.Controllers
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

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserDto request)
        {
            var response = await _authService.CreateUser(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            var response = await _authService.Login(request);
            if(response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet, Authorize]

        public async Task<ActionResult<string>> Aloha()
        {
            return "ALoha";
        }
    }
}
