using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class StrategyGameContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<CountryBuilding> CountryBuildings { get; set; }
        public DbSet<CountryUnit> CountryUnits { get; set; }
        public DbSet<CountryUpgrade> CountryUpgrades { get; set; }

        public StrategyGameContext(DbContextOptions<StrategyGameContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>().HasData(
                new Building { Id = 1, Name = "áramlásirányító", Price = 1000, Population = 50, Units = 0, CoralPerTurn = 200, Image = "img/undersea_game-07.png", StatImage = "svg/control-building.svg", Description = "50 embert ad a népességhez. 200 korallt termel körönként" },
                new Building { Id = 2, Name = "zátonyvár", Price = 1000, Population = 0, Units = 200, CoralPerTurn = 0, Image = "img/undersea_game-05.png", StatImage = "svg/castle-building.svg", Description = "200 egységnek nyújt szállást" }
            );
            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "rohamfóka", Price = 50, Attack = 6, Defense = 2, CostPerTurn = 1, CoralPerTurn = 1, Image = "svg/025-seal.svg" },
                new Unit { Id = 2, Name = "csatacsikó", Price = 50, Attack = 2, Defense = 6, CostPerTurn = 1, CoralPerTurn = 1, Image = "svg/013-seahorse.svg" },
                new Unit { Id = 3, Name = "lézercápa", Price = 100, Attack = 5, Defense = 5, CostPerTurn = 3, CoralPerTurn = 2, Image = "svg/007-shark.svg" }
            );
            modelBuilder.Entity<Upgrade>().HasData(
                new Upgrade { Id = 1, Name = "iszaptraktor", CoralBonus = 10, DefenseBonus = 0, AttackBonus = 0, TaxBonus = 0, Image = "img/undersea_game-09.png", Description = "növeli a korall termesztését 10%-kal" },
                new Upgrade { Id = 2, Name = "iszapkombájn", CoralBonus = 15, DefenseBonus = 0, AttackBonus = 0, TaxBonus = 0, Image = "img/undersea_game-10.png", Description = "növeli a korall termesztését 15%-kal" },
                new Upgrade { Id = 3, Name = "korallfal", CoralBonus = 0, DefenseBonus = 20, AttackBonus = 0, TaxBonus = 0, Image = "img/undersea_game-03.png", Description = "növeli a védelmi pontokat 20%-kal" },
                new Upgrade { Id = 4, Name = "szonár ágyú", CoralBonus = 0, DefenseBonus = 0, AttackBonus = 20, TaxBonus = 0, Image = "img/undersea_game-03.png", Description = "növeli a támadópontokat 20%-kal" },
                new Upgrade { Id = 5, Name = "vízalatti harcművészetek", CoralBonus = 0, DefenseBonus = 10, AttackBonus = 10, TaxBonus = 0, Image = "img/undersea_game-03.png", Description = "növeli a védelmi és támadóerőt 10%-kal" },
                new Upgrade { Id = 6, Name = "alkímia", CoralBonus = 0, DefenseBonus = 0, AttackBonus = 0, TaxBonus = 30, Image = "img/undersea_game-03.png", Description = "növeli a beszedett adót 30%-kal" }
            );
        }
    }
}