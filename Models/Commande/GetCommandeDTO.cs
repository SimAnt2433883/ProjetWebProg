using ProjetWebProg.Data;

namespace ProjetWebProg.Models.Commande
{
    public class GetCommandeDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Adresse Adresse { get; set; }
        public ToutouQuantiteDTO[] IdsToutousQuantites { get; set; }
    }
}

