using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public class MockUpgradeRepository : IUpgradeRepository
    {
        public IEnumerable<Upgrade> GetUpgradesForUser(int userId)
        {
            return new List<Upgrade> {
                new Upgrade{Id=1, Name="asd", CoralBonus=0, DefenseBonus=0, AttackBonus=10, TaxBonus=0},
                new Upgrade{Id=1, Name="asd", CoralBonus=0, DefenseBonus=10, AttackBonus=0, TaxBonus=0},
            };
        }
    }
}