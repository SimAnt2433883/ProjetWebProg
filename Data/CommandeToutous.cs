using Microsoft.AspNetCore.Identity;

namespace ProjetWebProg.Data
{
    public class CommandeToutous
    {
        public int Id { get; set; }
        public required int ToutousId { get; set; }
        public required int Quantite { get; set; }
    }
}
