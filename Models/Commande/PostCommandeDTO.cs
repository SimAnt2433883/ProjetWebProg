namespace ProjetWebProg.Models.Commande
{
    public class PostCommandeDTO
    {
        public int Id { get; set; }
        public (int, int)[] IdsToutousQuantites { get; set; }

    }
}
