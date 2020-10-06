using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IUpgradeRepository
    {
        IEnumerable<Upgrade> GetUpgradesForUser(int userId);
        Upgrade GetUpgradeById(int upgradeId, int userId);
        void CreateUpgradeForUser(Upgrade upgrade, int userId);
    }

    public class UpgradeRepository : IUpgradeRepository
    {
        private readonly StrategyGameContext _context;

        public UpgradeRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Upgrade> GetUpgradesForUser(int userId)
        {
            var user = FetchUserWithUpgrades(userId);
            return user.Country.Upgrades;
        }

        public Upgrade GetUpgradeById(int id, int userId)
        {
            var user = FetchUserWithUpgrades(userId);
            foreach (var upgrade in user.Country.Upgrades)
                if (upgrade.Id == id)
                    return upgrade;
            return null;
        }

        public void CreateUpgradeForUser(Upgrade upgrade, int userId)
        {
            var user = FetchUserWithUpgrades(userId);
            user.Country.Upgrades.Add(upgrade);
            _context.SaveChanges();
        }

        private ApplicationUser FetchUserWithUpgrades(int userId)
        {
            return _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Upgrades)
                .Single(user => user.Id == userId);
        }
    }
}