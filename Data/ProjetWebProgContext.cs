using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetWebProg.Data;

namespace ProjetWebProg.Data;

public class ProjetWebProgContext : IdentityDbContext<IdentityUser>
{
    public ProjetWebProgContext(DbContextOptions<ProjetWebProgContext> options)
        : base(options)
    {
    }

public DbSet<ProjetWebProg.Data.Toutous> Toutous { get; set; } = default!;
}