using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public class SqlUnitRepository : IUnitRepository
    {
        private readonly StrategyGameContext _context;

        public SqlUnitRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Unit> GetUnitsForUser(int userId)
        {
            return _context.Units
                .Where(unit => unit.UserId == userId)
                .ToList();
        }
    }
}