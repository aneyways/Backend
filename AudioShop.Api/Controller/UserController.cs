using AudioShop.Api.Domain; 
using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Mvc; 


namespace AudioShop.Api.Controller
{ 
    [Route("api/user")] 
    [ApiController] 


    public class UserController : ControllerBase    
    {
        public static List<User> _users = new();  
        public static int NextId = 1;

        [HttpGet("all")] 
        public IActionResult GetAllUsers() 
        {
            return Ok(_users);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) 
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) 
            {
                return NotFound(new { Message = $"User with {id} not found" });
            }
            return Ok(user);
        }

        [HttpPost("create")]    
        public IActionResult CreateUser([FromBody] User user) 
        {
          
            user.Id = NextId++;
            user.CreatedAt = DateTime.UtcNow;
            _users.Add(user);
            return Created( $"/api/user/{user.Id}", user );
        }   

            [HttpPut("{id}")]    
           public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {   
            var existinguser = _users.FirstOrDefault(u => u.Id == id);
            
            if (existinguser == null) 
            {
                return NotFound(new { Message = $"User with {id} not found" });
            }
            existinguser.Username = updatedUser.Username;
            existinguser.Email = updatedUser.Email;
            
            return Ok(existinguser);
            }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) 
            {
                return NotFound(new { Message = $"User with {id} not found" });
            }
            _users.Remove(user);
            return NoContent();
        }


    }
}