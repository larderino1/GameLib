using DbManager.Models;
using GameLib_Back.Services.ModeServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModesController : ControllerBase
    {
        private readonly IModeServices _modeService;

        public ModesController(IModeServices modeService)
        {
            _modeService = modeService;
        }

        // GET: api/Modes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mode>>> GetModes()
        {
            var modes = await _modeService.GetModeListAsync();

            if (modes == null || modes.Count() == 0)
            {
                return NoContent();
            }

            return Ok(modes);
        }

        // GET: api/Modes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mode>> GetMode(Guid id)
        {
            var mode = await _modeService.GetModeByIdAsync(id);

            if (mode == null)
            {
                return NotFound();
            }

            return mode;
        }

        // PUT: api/Modes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMode(Guid id, Mode mode)
        {
            if (id != mode.Id)
            {
                return BadRequest();
            }

            try
            {
                await _modeService.UpdateModeAsync(id, mode);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Modes
        [HttpPost]
        public async Task<ActionResult<Mode>> PostMode(Mode mode)
        {
            try
            {
                await _modeService.CreateModeAsync(mode);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetMode", new { id = mode.Id }, mode);
        }

        // DELETE: api/Modes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mode>> DeleteMode(Guid id)
        {
            var mode = await _modeService.DeleteModeAsync(id);

            if (mode == null)
            {
                return NotFound();
            }

            return mode;
        }
    }
}
