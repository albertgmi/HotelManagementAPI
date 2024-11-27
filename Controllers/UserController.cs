using HotelManagementAPI.Models.UserModels;
using HotelManagementAPI.Services.UserServiceFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto userDto)
        {
            _userService.RegisterUser(userDto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginUserDto loginDto)
        {
            var token = _userService.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
}
