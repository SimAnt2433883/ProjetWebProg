namespace ProjetWebProg.Models.Toutous
{
    public class GetToutousDTO
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public int Prix { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int NbrInventaire { get; set; }
        public bool CoupCoeur { get; set; }
        public bool Nouveau { get; set; }
        public required string PriceId { get; set; }
    }
}
