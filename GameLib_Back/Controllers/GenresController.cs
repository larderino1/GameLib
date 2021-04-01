using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbManager.Data;
using DbManager.Models;
using GameLib_Back.Services.GenreServices;

namespace GameLib_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreServices _genreService;

        public GenresController(IGenreServices genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var genres = await _genreService.GetGenreListAsync();

            if (genres == null || genres.Count() == 0)
            {
                return NoContent();
            }

            return Ok(genres);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(Guid id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(Guid id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            try
            {
                await _genreService.UpdateGenreAsync(id, genre);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            try
            {
                await _genreService.CreateGenreAsync(genre);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(Guid id)
        {
            var genre = await _genreService.DeleteGenreAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }
    }
}
