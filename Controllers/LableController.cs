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
    public class LableController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LableController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Lable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lable>>> Getlables()
        {
            return await _context.lables.ToListAsync();
        }

        [HttpGet("GetLable/{MoviesId}/{MovieStudioId}")]
        [Produces("application/xml")]
        public async Task<Lable> CreateLableForRent(int MoviesId, int MovieStudioId)
        {
            var lable = new Lable();


            var asd = await lable.GetEtikettData(_context, MoviesId, MovieStudioId);
            var XmlLable = lable.CreateLabel(lable);
            return XmlLable;






        }


        // GET: api/Lable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lable>> GetLable(int id)
        {
            var lable = await _context.lables.FindAsync(id);

            if (lable == null)
            {
                return NotFound();
            }

            return lable;
        }

        // PUT: api/Lable/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLable(int id, Lable lable)
        {
            if (id != lable.Id)
            {
                return BadRequest();
            }

            _context.Entry(lable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LableExists(id))
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

        // POST: api/Lable
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lable>> PostLable(Lable lable)
        {
            _context.lables.Add(lable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLable", new { id = lable.Id }, lable);
        }

        // DELETE: api/Lable/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lable>> DeleteLable(int id)
        {
            var lable = await _context.lables.FindAsync(id);
            if (lable == null)
            {
                return NotFound();
            }

            _context.lables.Remove(lable);
            await _context.SaveChangesAsync();

            return lable;
        }

        private bool LableExists(int id)
        {
            return _context.lables.Any(e => e.Id == id);
        }
    }
}
