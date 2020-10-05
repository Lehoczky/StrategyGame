using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetBuildingsForUser(int userId);
    }

    public class BuildingRepository : IBuildingRepository
    {
        private readonly StrategyGameContext _context;

        public BuildingRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Building> GetBuildingsForUser(int userId)
        {
            var user = _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Buildings)
                .Single(user => user.Id == userId);
            return user.Country.Buildings;
        }
    }
}