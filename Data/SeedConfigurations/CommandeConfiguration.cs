using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetWebProg.Data.SeedConfigurations
{
    public class CommandeConfiguration : IEntityTypeConfiguration<Commande>
    {
        public void Configure(EntityTypeBuilder<Commande> builder)
        {
            builder.HasData(
                new Commande { Id = 1, UserId = "a049c840-f589-46d3-9466-27237c9379ad", Payee = false }
            );
        }
    }
}
