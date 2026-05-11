using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetWebProg.Data.SeedConfigurations
{
    public class ToutousConfiguration : IEntityTypeConfiguration<Toutous>
    {
        public void Configure(EntityTypeBuilder<Toutous> builder)
        {
            builder.HasData(
                new Toutous { PriceId = "prod_UT7R60A6mzLKXK", Id = 1, Nom = "Bernard", Prix = 25, Description = "Ours en peluche brun classique", Image = "https://static.vecteezy.com/system/resources/previews/044/813/824/non_2x/cute-brown-teddy-bear-stuffed-animal-isolated-on-transparent-background-png.png", NbrInventaire = 10, CoupCoeur = true },
                new Toutous { PriceId = "prod_UT7SL1YLkDlt1x", Id = 2, Nom = "Lulu", Prix = 30, Description = "Lapin blanc aux longues oreilles", Image = "https://png.pngtree.com/png-vector/20250115/ourmid/pngtree-soft-and-cozy-stuffed-bunny-with-realistic-craftsmanship-png-image_15191464.png", NbrInventaire = 15 },
                new Toutous { PriceId = "prod_UT7SqFtj4oL2wS", Id = 3, Nom = "Félix", Prix = 20, Description = "Chat gris rayé tout doux", Image = "https://static.vecteezy.com/system/resources/previews/070/054/567/non_2x/pair-of-cat-plushies-with-soft-fur-brown-and-gray-stripes-sitting-side-by-side-cute-expression-perfect-for-children-cozy-home-decor-matching-toy-set-adorable-companion-png.png", NbrInventaire = 8 },
                new Toutous { PriceId = "prod_UT7SO49lGPaX9y", Id = 4, Nom = "Rosie", Prix = 35, Description = "Licorne rose avec crinière arc-en-ciel", Image = "https://static.vecteezy.com/system/resources/previews/055/131/915/non_2x/rainbow-unicorn-plush-toy-magical-creature-soft-toy-free-png.png", NbrInventaire = 12, Nouveau = true },
                new Toutous { PriceId = "prod_UT7SWfTzDr6gYf", Id = 5, Nom = "Maxou", Prix = 28, Description = "Chien beige avec grandes pattes", Image = "https://www.warmbuddy.com/wp-content/uploads/2025/06/Large-Tan-Lab.png", NbrInventaire = 6 },
                new Toutous { PriceId = "prod_UT7Tx0rMRjG6z2", Id = 6, Nom = "Nemo", Prix = 22, Description = "Poisson clown orange et blanc", Image = "https://static.vecteezy.com/system/resources/thumbnails/066/570/335/small/a-plush-clownfish-with-orange-and-white-stripes-against-a-plain-surrounding-space-is-presented-here-on-transparent-background-free-png.png", NbrInventaire = 20 },
                new Toutous { PriceId = "prod_UT7Tpa6QQoZEq1", Id = 7, Nom = "Bella", Prix = 40, Description = "Éléphant gris avec nœud rose", Image = "https://monde-elephant.com/cdn/shop/products/product-image-1110929609_1024x1024.png?v=1640630300", NbrInventaire = 5, CoupCoeur = true },
                new Toutous { PriceId = "prod_UT7TdWiC56wWkQ", Id = 8, Nom = "Coco", Prix = 18, Description = "Petit pingouin noir et blanc rigolo", Image = "https://static.vecteezy.com/system/resources/previews/058/987/777/non_2x/adorable-plush-penguin-toy-with-black-and-white-fur-cut-out-transparent-png.png", NbrInventaire = 14 },
                new Toutous { PriceId = "prod_UT7UzSCzcrLiKG", Id = 9, Nom  = "Pou", Prix = 8, Description = "Le toutou qui respire", Image = "https://fixcdn.hyonsu.com/attachments/911076301337669664/1499122232079814706/IMG_5199.jpg?ex=69f3a5e0&is=69f25460&hm=182938c660a25e01c0862e883cb9da57a3e20ae292f601f860db29ab86c16bc5&", CoupCoeur = true, Nouveau = true }
            );
        }
    }
}
