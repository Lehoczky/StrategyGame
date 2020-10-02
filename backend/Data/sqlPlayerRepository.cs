using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public class sqlPlayerRepository : IPlayerRepository
    {
        private readonly StrategyGameContext _context;

        public sqlPlayerRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(player => player.Id == id);
        }
    }
}