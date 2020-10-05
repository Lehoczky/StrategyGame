using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IUpgradeRepository
    {
        IEnumerable<Upgrade> GetUpgradesForUser(int userId);
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
            var user = _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Upgrades)
                .Single(user => user.Id == userId);
            return user.Country.Upgrades;
        }
    }
}