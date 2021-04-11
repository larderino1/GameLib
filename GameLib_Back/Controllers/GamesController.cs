using DbManager.Models;
using GameLib_Back.Services.GameServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameServices _gamesService;

        public GamesController(IGameServices gamesService)
        {
            _gamesService = gamesService;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            var games = await _gamesService.GetGameListAsync();

            if (games == null || games.Count() == 0)
            {
                return NoContent();
            }

            return Ok(games);
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(Guid id)
        {
            var game = await _gamesService.GetGameByIdAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(Guid id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            try
            {
                await _gamesService.UpdateGameAsync(id, game);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            try
            {
                await _gamesService.CreateGameAsync(game);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(Guid id)
        {
            var game = await _gamesService.DeleteGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }
    }
}
