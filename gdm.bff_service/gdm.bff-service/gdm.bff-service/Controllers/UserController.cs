using gdm.bff_service.Models;
using gdm.bff_service.Services;
using Microsoft.AspNetCore.Mvc;

namespace gdm.bff_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _userService.Register(user);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var token = _userService.Authenticate(user.Username, user.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }

}
