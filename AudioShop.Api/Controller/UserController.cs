using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudioShop.BusinessLogic.Core;
using AudioShop.BusinessLogic.Interfaces;
using AudioShop.Domains.Models.User;
using AudioShop.BusinessLogic;
using AudioShop.BusinessLogic.Functions;
using Microsoft.AspNetCore.Authorization;


namespace AudioShop.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserActions _userActions;

        public UserController()
        {
            var _bl = new AudioShop.BusinessLogic.BusinessLogic();
            _userActions = _bl.GetUserActions();
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var _users = _userActions.GetAllUsersAction();
            return Ok(_users);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateNewUser(UserCreateDto _user)
        {
            var _newUser = _userActions.CreateNewUserAction(_user);
            return Created($"/api/user/{_newUser.Id}", _newUser);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateUser(int id, UserCreateDto _user)
        {
            var _updatedUser = _userActions.UpdateUserAction(id, _user);

            if (_updatedUser == null) return NotFound();

            return Ok(_updatedUser);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(int id)
        {
            var IsDeleted = _userActions.DeleteUserAction(id);

            if (!IsDeleted) return NotFound();

            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            var _user = _userActions.GetUserByIdAction(id);

            if (_user == null) return NotFound();

            return Ok(_user);
        }
    }
}