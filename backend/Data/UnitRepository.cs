using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetUnitsForUser(int userId);
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
            var user = _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Units)
                .Single(user => user.Id == userId);
            return user.Country.Units;
        }
    }
}