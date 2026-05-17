using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AudioShop.BusinessLogic;
using AudioShop.BusinessLogic.Core;
using AudioShop.BusinessLogic.Functions;
// using AudioShop.API.Attributes;
// using AudioShop.API.Attributes;

namespace AudioShop.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserAction _userAction;
        public UserController()
        {
            var _bl = new AudioShop.BusinessLogic.BusinessLogic();
            _userAction = _bl.GetUserAction();
        }

        [HttpGet("all")]
        // [AdminMod]
        public IActionResult GetAllUsers()
        {
            var _users = _userAction.GetAllUsersAction();
            return Ok(_users);
        }

        [HttpPost]
        // [AdminMod]
        public IActionResult CreateNewUser(UserCreateDto _user)
        {
            var _newUser = _userAction.CreateNewUserAction(_user);
            return Created($"/api/user/{_newUser.Id}", _newUser);
        }

        [HttpPut("{id}")]
        // [UserMod]
        public IActionResult UpdateUser(int id, UserCreateDto _user)
        {
            var _updatedUser = _userAction.UpdateUserAction(id, _user);

            if (_updatedUser == null) return NotFound();

            return Ok(_updatedUser);
        }

        [HttpDelete("{id}")]
        // [AdminMod]
        public IActionResult DeleteUser(int id)
        {
            var IsDeleted = _userAction.DeleteUserAction(id);

            if (!IsDeleted) return NotFound();

            return NoContent();
        }

        [HttpGet("{id}")]
        // [UserMod]
        public IActionResult GetUserById(int id)
        {
            var _user = _userAction.GetUserByIdAction(id);

            if (_user == null) return NotFound();

            return Ok(_user);
        }
    }
}