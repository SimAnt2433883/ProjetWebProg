using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetWebProg.Data;

namespace ProjetWebProg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToutousController : ControllerBase
    {
        private readonly ProjetWebProgContext _context;

        public ToutousController(ProjetWebProgContext context)
        {
            _context = context;
        }

        // GET: api/Toutous
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toutous>>> GetToutous()
        {
            return await _context.Toutous.ToListAsync();
        }

        // GET: api/Toutous/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toutous>> GetToutous(int id)
        {
            var toutous = await _context.Toutous.FindAsync(id);

            if (toutous == null)
            {
                return NotFound();
            }

            return toutous;
        }

        // PUT: api/Toutous/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToutous(int id, Toutous toutous)
        {
            if (id != toutous.Id)
            {
                return BadRequest();
            }

            _context.Entry(toutous).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToutousExists(id))
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

        // POST: api/Toutous
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Toutous>> PostToutous(Toutous toutous)
        {
            _context.Toutous.Add(toutous);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToutous", new { id = toutous.Id }, toutous);
        }

        // DELETE: api/Toutous/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToutous(int id)
        {
            var toutous = await _context.Toutous.FindAsync(id);
            if (toutous == null)
            {
                return NotFound();
            }

            _context.Toutous.Remove(toutous);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToutousExists(int id)
        {
            return _context.Toutous.Any(e => e.Id == id);
        }
    }
}
