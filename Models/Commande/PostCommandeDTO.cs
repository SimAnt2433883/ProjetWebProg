using Microsoft.AspNetCore.Identity;
using ProjetWebProg.Data;
using ProjetWebProg.Models.Toutous;

namespace ProjetWebProg.Models.Commande
{
    public class ToutouQuantiteDTO
    {
        public int IdToutou { get; set; }
        public int Quantite { get; set; }
        public GetToutousDTO? Toutou { get; set; }
    }

    public class PostCommandeDTO
    {
        public int Id { get; set; }
        public Adresse Adresse { get; set; }
        public ToutouQuantiteDTO[] IdsToutousQuantites { get; set; }
    }
}
