using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class StrategyGameContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public StrategyGameContext(DbContextOptions<StrategyGameContext> opts) : base(opts) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
    }
}