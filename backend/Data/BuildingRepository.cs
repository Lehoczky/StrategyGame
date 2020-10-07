using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using System;
using System.Threading.Tasks;

namespace backend.Data
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<Building>> GetBuildingsForUser(int userId);
        Task<Building> GetBuildingById(int buildingId, int userId);
        Task<Building> CreateBuildingForUser(string buildingType, int userId);
    }

    public class BuildingRepository : IBuildingRepository
    {
        private readonly StrategyGameContext _context;

        public BuildingRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Building>> GetBuildingsForUser(int userId)
        {
            var user = await FetchUserWithBuildings(userId);
            return user.Country.Buildings;
        }

        public async Task<Building> GetBuildingById(int id, int userId)
        {
            var user = await FetchUserWithBuildings(userId);
            foreach (var building in user.Country.Buildings)
                if (building.Id == id)
                    return building;
            return null;
        }

        public async Task<Building> CreateBuildingForUser(string buildingType, int userId)
        {
            var user = await FetchUserWithBuildings(userId);
            var building = ModelForType(buildingType);
            user.Country.Buildings.Add(building);
            await _context.SaveChangesAsync();
            return building;
        }

        private async Task<ApplicationUser> FetchUserWithBuildings(int userId)
        {
            return await _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Buildings)
                .SingleOrDefaultAsync(user => user.Id == userId);
        }

        private Building ModelForType(string type)
        {
            switch (type)
            {
                case "flowController":
                    return new Building
                    {
                        Name = "áramlásirányító",
                        Price = 1000,
                        Population = 50,
                        Units = 0,
                        CoralPerTurn = 200
                    };
                case "reefCastle":
                    return new Building
                    {
                        Name = "zátonyvár",
                        Price = 1000,
                        Population = 0,
                        Units = 200,
                        CoralPerTurn = 0
                    };
                default:
                    throw new ArgumentException("Invalid building type");
            }
        }
    }
}