namespace ProjetWebProg.Data
{
    public class Adresse
    {
        public int Id { get; set; }
        public int NoCivique { get; set; }
        public string TypeRue { get; set; }
        public string NomRue { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string Pays { get; set; }
    }
}
