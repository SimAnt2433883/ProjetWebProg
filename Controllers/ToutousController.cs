using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<ToutousController> _logger;

        public ToutousController(ProjetWebProgContext context)
        {
            _context = context;
        }

        // GET: api/Toutous
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Toutous>>> GetToutous()
        {
            return await _context.Toutous.ToListAsync();
        }

        // GET: api/Toutous/5
        [HttpGet("{id}")]
        [AllowAnonymous]
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
        [Authorize(Roles ="Administrateur")]
        public async Task<IActionResult> PutToutous(int id, Toutous toutous)
        {
            
            try
            {
                if (id != toutous.Id)
                {
                    return BadRequest();
                }
                var toutousModifier = await _context.Toutous.FindAsync(id);
                if (toutousModifier == null)
                    return BadRequest();

                _context.Entry(toutous).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Le toutout a deja ete modifier");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Exeption {e}", ex.Message);
                return StatusCode(500, new
                { 
                    Message = "Une erreur est survenu.",
                    Error = ex.Message
                });
            }

            return NoContent();
        }

        // POST: api/Toutous
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult<Toutous>> PostToutous(Toutous toutous)
        {

            _context.Toutous.Add(toutous);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToutous", new { id = toutous.Id }, toutous);
        }

        // DELETE: api/Toutous/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Adminstrateur")]
        public async Task<IActionResult> DeleteToutous(int id)
        {
            
            try
            {
                var toutous = await _context.Toutous.FindAsync(id);
                if (toutous == null)
                {
                    return NotFound();
                }
                
                _context.Toutous.Remove(toutous);
                await _context.SaveChangesAsync();
                              

            }
            catch(DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Exeption{e}", ex.Message);
                return StatusCode(500, new
                {
                    Message = "Une erreur est survenue.",
                    Error = ex.Message
                });
            
            }
            
         

            return NoContent();
        }

    }
}
