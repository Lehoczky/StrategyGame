using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int id);
    }

    public class PlayerRepository : IPlayerRepository
    {
        private readonly StrategyGameContext _context;

        public PlayerRepository(StrategyGameContext context)
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