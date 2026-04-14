using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjetWebProg.Data;
using ProjetWebProg.Data.SeedConfigurations;

namespace ProjetWebProg.Data;

public class ProjetWebProgContext(DbContextOptions<ProjetWebProgContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Toutous> Toutous { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ToutousConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new CommandeConfiguration());
        modelBuilder.ApplyConfiguration(new CommandeToutousConfiguration());
    }

public DbSet<ProjetWebProg.Data.Commande> Commande { get; set; } = default!;

}