using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int id);
    }
}