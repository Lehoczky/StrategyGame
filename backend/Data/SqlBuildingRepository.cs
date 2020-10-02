using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public class SqlBuildingRepository : IBuildingRepository
    {
        private readonly StrategyGameContext _context;

        public SqlBuildingRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Building> GetBuildingsForPlayer(int userId)
        {
            return _context.Buildings
                .Where(building => building.PlayerId == userId)
                .ToList();
        }
    }
}