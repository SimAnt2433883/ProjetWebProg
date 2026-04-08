using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetWebProg.Data.SeedConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMINISTRATEUR",
                },
                new IdentityRole
                {
                    Name = "Utilisateur",
                    NormalizedName = "UTILISATEUR"
                });
            
            //throw new NotImplementedException();
        }
    }
}
