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
    public class RentedMoviesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public RentedMoviesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/RentedMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentedMovies>>> GetRentedMovies()
        {
            return await _context.RentedMovies.ToListAsync();
        }

        // GET: api/RentedMovies/5
        [HttpGet("GetRentedMovies{id}")]
        public async Task<ActionResult<RentedMovies>> GetRentedMovies(int id)
        {
            var rentedMovies = await _context.RentedMovies.FindAsync(id);

            if (rentedMovies == null)
            {
                return NotFound();
            }

            return rentedMovies;
        }

        // PUT: api/RentedMovies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentedMovies(int id, RentedMovies rentedMovies)
        {
            if (id != rentedMovies.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentedMovies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentedMoviesExists(id))
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

        // POST: api/RentedMovies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RentedMovies>> PostRentedMovies(RentedMovies rentedMovies)
        {
            _context.RentedMovies.Add(rentedMovies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentedMovies", new { id = rentedMovies.Id }, rentedMovies);
        }

        // DELETE: api/RentedMovies/5
        [HttpDelete("DeleteRentedMovieFromMovieStudio{id}")]
        public async Task<ActionResult<RentedMovies>> DeleteRentedMovies(int id)
        {
            var rentedMovies = await _context.RentedMovies.FindAsync(id);
            if (rentedMovies == null)
            {
                return NotFound();
            }

            _context.RentedMovies.Remove(rentedMovies);
            await _context.SaveChangesAsync();

            return rentedMovies;
        }

        [HttpPost("AddRentedMovie/{studioId}/{movieId}")]
        public async Task<ActionResult<RentedMovies>> PostMovieToStudio(int studioId, int movieId)
        {
            var movieStudio = await _context.MovieStudio.Where(m => m.Id == studioId).FirstOrDefaultAsync();

            if (movieStudio != null)
            {
                var movie = await _context.Movies.Where(m => m.Id == movieId).FirstOrDefaultAsync();

                movieStudio.AddRentedMovie(movie);

                await _context.SaveChangesAsync();

                return StatusCode(201);
            }
            return StatusCode(400);

        }

        private bool RentedMoviesExists(int id)
        {
            return _context.RentedMovies.Any(e => e.Id == id);
        }
    }
}
