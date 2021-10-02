
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{ 
    [Route("v1/api/internal/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        [HttpGet("test")]
        public ActionResult TestConnection()
        {
            return Ok("Inbound from Platfrom services");
        }
    }
}