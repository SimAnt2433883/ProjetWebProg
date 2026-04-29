using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetWebProg.Data.SeedConfigurations
{
    public class CommandeToutousConfiguration : IEntityTypeConfiguration<CommandeToutous>
    {
        public void Configure(EntityTypeBuilder<CommandeToutous> builder)
        {
            builder.HasKey(ct => new { ct.IdCommande, ct.IdToutou });

            builder.HasOne(ct => ct.Toutous)
                .WithMany()
                .HasForeignKey(ct => ct.IdToutou);

            builder.HasOne(ct => ct.Commande)
                .WithMany()
                .HasForeignKey(ct => ct.IdCommande);
        }
    }
}
