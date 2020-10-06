using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetUnitsForUser(int userId);
        Unit GetUnitById(int unitid, int userId);
        void CreateUnitForUser(Unit unit, int userId);
    }

    public class UnitRepository : IUnitRepository
    {
        private readonly StrategyGameContext _context;

        public UnitRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Unit> GetUnitsForUser(int userId)
        {
            var user = FetchUserWithUnits(userId);
            return user.Country.Units;
        }

        public Unit GetUnitById(int id, int userId)
        {
            var user = FetchUserWithUnits(userId);
            foreach (var unit in user.Country.Units)
                if (unit.Id == id)
                    return unit;
            return null;
        }

        public void CreateUnitForUser(Unit unit, int userId)
        {
            var user = FetchUserWithUnits(userId);
            user.Country.Units.Add(unit);
            _context.SaveChanges();
        }

        private ApplicationUser FetchUserWithUnits(int userId)
        {
            return _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Units)
                .Single(user => user.Id == userId);
        }
    }
}