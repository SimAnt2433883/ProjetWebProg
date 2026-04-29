using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetWebProg.Data;
using ProjetWebProg.Models.Commande;
using ProjetWebProg.Models.Toutous;
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
        public async Task<ActionResult<IEnumerable<GetCommandeDTO>>> GetCommande()
        {
            var commandes = await _context.Commande
                .Include(c => c.Adresse)
                .ToListAsync();

            List<GetCommandeDTO> result = new();

            foreach (var commande in commandes)
            {
                GetCommandeDTO dto = _mapper.Map<GetCommandeDTO>(commande);

                dto.UserId = commande.UserId;

                dto.IdsToutousQuantites = await _context.CommandeToutous
                    .Where(ct => ct.IdCommande == commande.Id)
                    .Select(ct => new ToutouQuantiteDTO
                    {
                        IdToutou = ct.IdToutou,
                        Quantite = ct.Quantite,
                        Toutou = new GetToutousDTO
                        {
                            Id = ct.Toutous.Id,
                            Nom = ct.Toutous.Nom,
                            Prix = ct.Toutous.Prix,
                            Description = ct.Toutous.Description,
                            Image = ct.Toutous.Image,
                            NbrInventaire = ct.Toutous.NbrInventaire
                        }
                    })
                    .ToArrayAsync();

                result.Add(dto);
            }

            return result;
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GetCommandeDTO>> GetCommande(int id)
        {
            Commande? commande = await _context.Commande
                .Include(c => c.Adresse)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (commande == null)
                return NotFound();

            bool isAdmin = User.IsInRole("Administrateur");
            if (commande.UserId != GetUserId() && !isAdmin)
                return Unauthorized();

            GetCommandeDTO getCommandeDTO = _mapper.Map<GetCommandeDTO>(commande);

            getCommandeDTO.IdsToutousQuantites = await _context.CommandeToutous
            .Where(ct => ct.IdCommande == id)
            .Select(ct => new ToutouQuantiteDTO
            {
                IdToutou = ct.IdToutou,
                Quantite = ct.Quantite,
                Toutou = new GetToutousDTO
                {
                    Id = ct.Toutous.Id,
                    Nom = ct.Toutous.Nom,
                    Prix = ct.Toutous.Prix,
                    Description = ct.Toutous.Description,
                    Image = ct.Toutous.Image,
                    NbrInventaire = ct.Toutous.NbrInventaire
                }

            })
            .ToArrayAsync();

            return getCommandeDTO;
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
            commande.UserId = GetUserId();
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

            var fullCommande = await _context.Commande
                .Include(c => c.Adresse)
                .FirstOrDefaultAsync(c => c.Id == commande.Id);

            var result = _mapper.Map<GetCommandeDTO>(fullCommande);

            result.IdsToutousQuantites = await _context.CommandeToutous
                .Where(ct => ct.IdCommande == commande.Id)
                .Select(ct => new ToutouQuantiteDTO
                {
                    IdToutou = ct.IdToutou,
                    Quantite = ct.Quantite,
                    Toutou = new GetToutousDTO
                    {
                        Id = ct.Toutous.Id,
                        Nom = ct.Toutous.Nom,
                        Prix = ct.Toutous.Prix,
                        Description = ct.Toutous.Description,
                        Image = ct.Toutous.Image,
                        NbrInventaire = ct.Toutous.NbrInventaire
                    }
                })
                .ToArrayAsync();

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

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}