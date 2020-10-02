using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IUpgradeRepository
    {
        IEnumerable<Upgrade> GetUpgradesForPlayer(int userId);
    }
    
    public class SqlUpgradeRepository : IUpgradeRepository
    {
        private readonly StrategyGameContext _context;

        public SqlUpgradeRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Upgrade> GetUpgradesForPlayer(int userId)
        {
            return _context.Upgrades
                .Where(upgrade => upgrade.PlayerId == userId)
                .ToList();
        }
    }
}