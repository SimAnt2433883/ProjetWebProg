using Microsoft.AspNetCore.Identity;

namespace ProjetWebProg.Data
{
    public class Commande
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public IdentityUser? User { get; set; }
        public bool Payee { get; set; }
        public int AdresseId { get; set; }
        public Adresse Adresse { get; set; }

        
    }
}
