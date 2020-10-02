using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetBuildingsForPlayer(int userId);
    }
}