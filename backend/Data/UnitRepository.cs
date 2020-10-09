using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using backend.DTOs;
using System.Threading.Tasks;
using static backend.Helpers.Helpers;

namespace backend.Data
{
    public interface IUnitRepository
    {
        Task<IEnumerable<CountryUnit>> GetUnitsForUser(int userId);
        Task<CountryUnit> GetUnitsById(int unitId, int userId);
        Task<CountryUnit> CreateUnitsForUser(UnitCreateDto units, int userId);
        Task<IEnumerable<Unit>> GetUnitTypes();
    }

    public class UnitRepository : IUnitRepository
    {
        private readonly StrategyGameContext _context;

        public UnitRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CountryUnit>> GetUnitsForUser(int userId)
        {
            var user = await FetchUserWithUnits(userId);
            return user.Country.Units;
        }

        public async Task<CountryUnit> GetUnitsById(int id, int userId)
        {
            var user = await FetchUserWithUnits(userId);
            foreach (var unit in user.Country.Units)
            {
                if (unit.Id == id)
                {
                    return unit;
                }
            }
            return null;
        }

        public async Task<CountryUnit> CreateUnitsForUser(UnitCreateDto units, int userId)
        {
            var user = await FetchUserWithUnits(userId);
            var unit = await _context.Units
                .Where(u => u.Name == units.Name)
                .SingleOrDefaultAsync();

            var cost = unit.Price * units.Count;
            Pay(user, cost);
            var countryUnit = AddUnitToUser(unit, units.Count, user);
            await _context.SaveChangesAsync();
            return countryUnit;
        }

        public async Task<IEnumerable<Unit>> GetUnitTypes()
        {
            return await _context.Units.ToListAsync();
        }

        private async Task<ApplicationUser> FetchUserWithUnits(int userId)
        {
            return await _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Units)
                    .ThenInclude(u => u.Unit)
                .SingleAsync(user => user.Id == userId);
        }

        private CountryUnit AddUnitToUser(Unit unit, int count, ApplicationUser user)
        {
            CountryUnit cu = null;
            foreach (var countryUnits in user.Country.Units)
            {
                if (countryUnits.Unit == unit)
                {
                    cu = countryUnits;
                }
            }
            if (cu != null)
            {
                cu.Count += count;
            }
            else
            {
                cu = new CountryUnit { Count = count, Unit = unit };
                user.Country.Units.Add(cu);
            }
            return cu;
        }
    }
}