using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSFIEF;

namespace SSFIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStudioController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MovieStudioController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieStudio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieStudio>>> GetMovieStudio()
        {
            return await _context.MovieStudio.ToListAsync();
        }

        // GET: api/MovieStudio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieStudio>> GetMovieStudio(int id)
        {
            var movieStudio = await _context.MovieStudio.FindAsync(id);

            if (movieStudio == null)
            {
                return NotFound();
            }

            return movieStudio;
        }
        // PUT: api/MovieStudio/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieStudio(int id, MovieStudio movieStudio)
        {
            if (id != movieStudio.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieStudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieStudioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieStudio
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
        [HttpDelete("DeleteMovieStudio{id}")]
        public async Task<ActionResult<MovieStudio>> DeleteMovieStudio(int id)
        {
            var movieStudio = await _context.MovieStudio.FindAsync(id);
            if (movieStudio == null)
            {

                return NotFound();
            }

            _context.MovieStudio.Remove(movieStudio);
            await _context.SaveChangesAsync();

            return movieStudio;
        }

        [HttpPost]
        public async Task<ActionResult<MovieStudio>> PostMovieStudio(MovieStudio movieStudio)
        {
            _context.MovieStudio.Add(movieStudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieStudio", new {Id = movieStudio.Id}, movieStudio);
        }

        private bool MovieStudioExists(int id)
        {
            return _context.MovieStudio.Any(e => e.Id == id);
        }
    }
}
