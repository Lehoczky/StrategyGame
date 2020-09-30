using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public class sqlUserRepository : IUserRepository
    {
        private readonly StrategyGameContext _context;

        public sqlUserRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }
    }
}