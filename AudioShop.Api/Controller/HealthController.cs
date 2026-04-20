using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet ("ping")]
        public IActionResult Ping()
        {
            var currentTime = DateTime.UtcNow;  
            return Ok("pong");
        }   
    }
}
