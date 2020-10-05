using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface ICountryRepository
    {
        Country GetCountryForUser(int userId);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly StrategyGameContext _context;

        public CountryRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public Country GetCountryForUser(int userId)
        {
            var user = _context.Users
                .Include(user => user.Country)
                .Single(user => user.Id == userId);
            return user.Country;
        }
    }
}