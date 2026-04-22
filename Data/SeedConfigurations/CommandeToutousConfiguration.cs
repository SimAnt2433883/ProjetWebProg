using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetWebProg.Data.SeedConfigurations
{
    public class CommandeToutousConfiguration : IEntityTypeConfiguration<CommandeToutous>
    {
        public void Configure(EntityTypeBuilder<CommandeToutous> builder)
        {
            builder.HasData(
                new CommandeToutous { Id = 1, ToutousId = 4, Quantite = 10 }
            );
        }
    }
}
