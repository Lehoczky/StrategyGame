using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;

namespace backend.Data
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetBuildingsForUser(int userId);
        Building GetBuildingById(int buildingId, int userId);
        void CreateBuildingForUser(Building building, int userId);
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
            var user = FetchUserWithBuildings(userId);
            return user.Country.Buildings;
        }

        public Building GetBuildingById(int id, int userId)
        {
            var user = FetchUserWithBuildings(userId);
            foreach (var building in user.Country.Buildings)
                if (building.Id == id)
                    return building;
            return null;
        }

        public void CreateBuildingForUser(Building building, int userId)
        {
            var user = FetchUserWithBuildings(userId);
            user.Country.Buildings.Add(building);
            _context.SaveChanges();
        }

        private ApplicationUser FetchUserWithBuildings(int userId)
        {
            return _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Buildings)
                .Single(user => user.Id == userId);
        }
    }
}