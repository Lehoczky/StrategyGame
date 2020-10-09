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
        public DbSet<Round> Rounds { get; set; }

        public StrategyGameContext(DbContextOptions<StrategyGameContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FlowController>().HasBaseType(typeof(Building));
            modelBuilder.Entity<ReefCastle>().HasBaseType(typeof(Building));

            modelBuilder.Entity<FlowController>().HasData(
                new FlowController { Id = 1, Name = "áramlásirányító", Price = 1000, Population = 50, CoralPerTurn = 200, Image = "img/undersea_game-05.png", StatImage = "svg/castle-building.svg", Description = "50 embert ad a népességhez. 200 korallt termel körönként" }
            );
            modelBuilder.Entity<ReefCastle>().HasData(
                new ReefCastle { Id = 2, Name = "zátonyvár", Price = 1000, Units = 200, Image = "img/undersea_game-05.png", StatImage = "svg/castle-building.svg", Description = "200 egységnek nyújt szállást" }
            );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { Id = 1, Name = "rohamfóka", Price = 50, Attack = 6, Defense = 2, CostPerTurn = 1, CoralPerTurn = 1, Image = "svg/025-seal.svg" },
                new Unit { Id = 2, Name = "csatacsikó", Price = 50, Attack = 2, Defense = 6, CostPerTurn = 1, CoralPerTurn = 1, Image = "svg/013-seahorse.svg" },
                new Unit { Id = 3, Name = "lézercápa", Price = 100, Attack = 5, Defense = 5, CostPerTurn = 3, CoralPerTurn = 2, Image = "svg/007-shark.svg" }
            );

            modelBuilder.Entity<MudTractor>().HasBaseType(typeof(Upgrade));
            modelBuilder.Entity<MudCombine>().HasBaseType(typeof(Upgrade));
            modelBuilder.Entity<CoralWall>().HasBaseType(typeof(Upgrade));
            modelBuilder.Entity<SonarCannon>().HasBaseType(typeof(Upgrade));
            modelBuilder.Entity<UndergroundMartialArts>().HasBaseType(typeof(Upgrade));
            modelBuilder.Entity<Alchemy>().HasBaseType(typeof(Upgrade));

            modelBuilder.Entity<MudTractor>().HasData(
                new MudTractor { Id = 1, Name = "iszaptraktor", CoralBonus = 10, Image = "img/undersea_game-09.png", Description = "növeli a korall termesztését 10%-kal" }
            );
            modelBuilder.Entity<MudCombine>().HasData(
                new MudCombine { Id = 2, Name = "iszapkombájn", CoralBonus = 15, Image = "img/undersea_game-10.png", Description = "növeli a korall termesztését 15%-kal" }
            );
            modelBuilder.Entity<CoralWall>().HasData(
                new CoralWall { Id = 3, Name = "korallfal", DefenseBonus = 20, Image = "img/undersea_game-03.png", Description = "növeli a védelmi pontokat 20%-kal" }
            );
            modelBuilder.Entity<SonarCannon>().HasData(
                new SonarCannon { Id = 4, Name = "szonár ágyú", AttackBonus = 20, Image = "img/undersea_game-03.png", Description = "növeli a támadópontokat 20%-kal" }
            );
            modelBuilder.Entity<UndergroundMartialArts>().HasData(
                new UndergroundMartialArts { Id = 5, Name = "vízalatti harcművészetek", DefenseBonus = 10, AttackBonus = 10, Image = "img/undersea_game-03.png", Description = "növeli a védelmi és támadóerőt 10%-kal" }
            );
            modelBuilder.Entity<Alchemy>().HasData(
                new Alchemy { Id = 6, Name = "alkímia", TaxBonus = 30, Image = "img/undersea_game-03.png", Description = "növeli a beszedett adót 30%-kal" }
            );
        }
    }
}