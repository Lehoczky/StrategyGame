using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class StrategyGameContext : IdentityDbContext
    {
        public StrategyGameContext(DbContextOptions<StrategyGameContext> opts) : base(opts) { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}