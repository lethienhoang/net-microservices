using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Services;
using System.Collections.Generic;

namespace PlatformService.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAll()
        {
            var platforms = _platformService.GetAll();
            return Ok(platforms);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetById(int id)
        {
            var platform = _platformService.GetById(id);
            if (platform == null)
            {
                return NotFound("platform not found");
            }

            return Ok(platform);
        }

        [HttpPost("")]
        public ActionResult<PlatformReadDto> Insert([FromBody] PlatformCreateDto platformCreateDto)
        {
            _platformService.Insert(platformCreateDto);

            return Ok("platform is created");
        }
    }
}
