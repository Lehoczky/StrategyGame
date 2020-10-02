using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetUnitsForPlayer(int userId);
    }

    public class UnitRepository : IUnitRepository
    {
        private readonly StrategyGameContext _context;

        public UnitRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Unit> GetUnitsForPlayer(int userId)
        {
            return _context.Units
                .Where(unit => unit.PlayerId == userId)
                .ToList();
        }
    }
}