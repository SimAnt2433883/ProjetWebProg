using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetWebProg.Data.SeedConfigurations
{
    public class ToutousConfiguration : IEntityTypeConfiguration<Toutous>
    {
        public void Configure(EntityTypeBuilder<Toutous> builder)
        {
            builder.HasData(
                new Toutous { Id = 1, Nom = "Bernard", Prix = 25, Description = "Ours en peluche brun classique", Image = "bernard.jpg", NbrInventaire = 10 },
                new Toutous { Id = 2, Nom = "Lulu", Prix = 30, Description = "Lapin blanc aux longues oreilles", Image = "lulu.jpg", NbrInventaire = 15 },
                new Toutous { Id = 3, Nom = "Félix", Prix = 20, Description = "Chat gris rayé tout doux", Image = "felix.jpg", NbrInventaire = 8 },
                new Toutous { Id = 4, Nom = "Rosie", Prix = 35, Description = "Licorne rose avec crinière arc-en-ciel", Image = "rosie.jpg", NbrInventaire = 12 },
                new Toutous { Id = 5, Nom = "Maxou", Prix = 28, Description = "Chien beige avec grandes pattes", Image = "maxou.jpg", NbrInventaire = 6 },
                new Toutous { Id = 6, Nom = "Nemo", Prix = 22, Description = "Poisson clown orange et blanc", Image = "nemo.jpg", NbrInventaire = 20 },
                new Toutous { Id = 7, Nom = "Bella", Prix = 40, Description = "Éléphant gris avec nœud rose", Image = "bella.jpg", NbrInventaire = 5 },
                new Toutous { Id = 8, Nom = "Coco", Prix = 18, Description = "Petit pingouin noir et blanc rigolo", Image = "coco.jpg", NbrInventaire = 14 }
            );
        }
    }
}
