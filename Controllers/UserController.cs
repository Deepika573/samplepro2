using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using samplepro2.Interfaces.Business;
using samplepro2.Models;

namespace samplepro2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // POST api/user/login
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginModel user)
        {
            var token = _userManager.Login(user.UserName, user.Password);

            if (token == null || token == String.Empty)
                return BadRequest(new { message = "User name or password is incorrect" });

            return Ok(token);
        }
    }
}
