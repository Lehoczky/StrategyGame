using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using System.Threading.Tasks;

namespace backend.Data
{
    public interface ICountryRepository
    {
        Task<Country> GetCountryForUser(int userId);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly StrategyGameContext _context;

        public CountryRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public async Task<Country> GetCountryForUser(int userId)
        {
            var user = await _context.Users
                .Include(user => user.Country)
                .SingleOrDefaultAsync(user => user.Id == userId);
            return user.Country;
        }
    }
}