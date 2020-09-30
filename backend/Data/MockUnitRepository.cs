using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public class MockUnitRepository : IUnitRepository
    {
        public IEnumerable<Unit> GetUnitsForUser(int userId)
        {
            return new List<Unit> {
                new Unit{Id=1, Price=500, Attack=100, Defense=0, CostPerTurn=6, CoralPerTurn=2},
                new Unit{Id=2, Price=500, Attack=100, Defense=0, CostPerTurn=6, CoralPerTurn=2},
                new Unit{Id=3, Price=500, Attack=100, Defense=0, CostPerTurn=6, CoralPerTurn=2},
                new Unit{Id=4, Price=500, Attack=100, Defense=0, CostPerTurn=6, CoralPerTurn=2},
            };
        }
    }
}