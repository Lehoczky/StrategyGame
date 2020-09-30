using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public class MockBuildingRepository : IBuildingRepository
    {
        public IEnumerable<Building> GetBuildingsForUser(int userId)
        {
            return new List<Building> {
                new Building{Id=1, Price=500, Population=100, Units=0, CoralPerTurn=2},
                new Building{Id=2, Price=200, Population=0, Units=10, CoralPerTurn=12},
            };
        }
    }
}