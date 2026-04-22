using ProjetWebProg.Data;

public class CommandeToutous
{
    public int Id { get; set; }
    public int IdCommande { get; set; }
    public int IdToutou { get; set; }
    public int Quantite { get; set; }
    public Commande? Commande { get; set; }
    public Toutous? Toutous { get; set; }
}