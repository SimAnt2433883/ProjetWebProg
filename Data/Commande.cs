using Microsoft.AspNetCore.Identity;

namespace ProjetWebProg.Data
{
    public class Commande
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public IdentityUser? User { get; set; }
        public bool Payee { get; set; }
        public int NoCivique { get; set; }
        public string TypeRue { get; set; }
        public string NomRue { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string Pays { get; set; }
    }
}
