using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudioShop.BusinessLogic;
using AudioShop.DataAccess.Context;
using AudioShop.Domains.Models.Auth;
using AudioShop.BusinessLogic.Interface;

namespace AudioShop.API.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthActions _authActions;

        public AuthController()
        {
            var _bl = new AudioShop.BusinessLogic.BusinessLogic();
            _authActions = _bl.GetAuthActions();
        }

        [HttpPost("auth")]
        public IActionResult Login([FromBody] LoginDto _login)
        {
            var token = _authActions.LoginAction(_login);
            if (token == null) return Unauthorized("Invalid credentials");
            return Ok(new { token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto _register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = _authActions.RegisterAction(_register);
            if (token == null) return BadRequest("User already exists");
            return Ok(new { token });
        }
    }
}