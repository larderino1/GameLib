using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbManager.Data;
using DbManager.Models;
using GameLib_Back.Services.PlatformServices;

namespace GameLib_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformServices _platformService;

        public PlatformsController(IPlatformServices platformService)
        {
            _platformService = platformService;
        }

        // GET: api/Platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> GetPlatforms()
        {
            var platforms = await _platformService.GetPlatformsListAsync();

            if (platforms == null || platforms.Count() == 0)
            {
                return NoContent();
            }

            return Ok(platforms);
        }

        // GET: api/Platforms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Platform>> GetPlatform(Guid id)
        {
            var platform = await _platformService.GetPlatformByIdAsync(id);

            if (platform == null)
            {
                return NotFound();
            }

            return platform;
        }

        // PUT: api/Platforms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatform(Guid id, Platform platform)
        {
            if (id != platform.Id)
            {
                return BadRequest();
            }

            try
            {
                await _platformService.UpdatePlatformAsync(id, platform);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Platforms
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        {
            try
            {
                await _platformService.CreatePlatformAsync(platform);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetPlatform", new { id = platform.Id }, platform);
        }

        // DELETE: api/Platforms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Platform>> DeletePlatform(Guid id)
        {
            var platform = await _platformService.DeletePlatformAsync(id);

            if (platform == null)
            {
                return NotFound();
            }

            return platform;
        }
    }
}
