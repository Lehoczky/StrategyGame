using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class StrategyGameContext : DbContext
    {
        public StrategyGameContext(DbContextOptions<StrategyGameContext> opts) : base(opts) { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<User> Users { get; set; }
    }
}