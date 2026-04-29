using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetWebProg.Data;
using ProjetWebProg.Models.Commande;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetWebProg.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {
        private readonly ProjetWebProgContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public CommandesController(ProjetWebProgContext context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: api/Commandes
        [HttpGet]
        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommande()
        {
            return await _context.Commande.ToListAsync();
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            Commande? commande = await _context.Commande.FindAsync(id);

            if (commande == null)
                return NotFound();

            return commande;
        }

        // PUT: api/Commandes/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrateur")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.Id)
            {
                return BadRequest();
            }

            _context.Entry(commande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
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

        // POST: api/Commandes
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostCommandeDTO>> PostCommande(PostCommandeDTO commandeDto)
        {
            Console.WriteLine($"Count: {commandeDto.IdsToutousQuantites?.Length ?? 0}");
            Commande commande = _mapper.Map<Commande>(commandeDto);
            commande.UserId = await GetUserId();
            commande.Payee = false;

            _context.Commande.Add(commande);
            await _context.SaveChangesAsync();

            foreach (ToutouQuantiteDTO tq in commandeDto.IdsToutousQuantites)
            {
                _context.CommandeToutous.Add(new CommandeToutous
                {
                    IdCommande = commande.Id,
                    IdToutou = tq.IdToutou,
                    Quantite = tq.Quantite
                });
            }
            await _context.SaveChangesAsync();

            PostCommandeDTO result = _mapper.Map<PostCommandeDTO>(commande);
            result.IdsToutousQuantites = commandeDto.IdsToutousQuantites; // add this
            return CreatedAtAction(nameof(GetCommande), new { id = commande.Id }, result);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrateur")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commande = await _context.Commande.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }

            _context.Commande.Remove(commande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandeExists(int id)
        {
            return _context.Commande.Any(e => e.Id == id);
        }

        private async Task<string?> GetUserId()
        {
            string? username = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                ?? HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByNameAsync(username);
            return user?.Id;
        }
    }
}