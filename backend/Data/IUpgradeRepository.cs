using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public interface IUpgradeRepository
    {
        IEnumerable<Upgrade> GetUpgradesForPlayer(int userId);
    }
}