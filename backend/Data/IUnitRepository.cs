using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetUnitsForUser(int userId);
    }
}