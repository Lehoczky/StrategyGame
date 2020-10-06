using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using System;

namespace backend.Data
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetBuildingsForUser(int userId);
        Building GetBuildingById(int buildingId, int userId);
        Building CreateBuildingForUser(string buildingType, int userId);
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

        public Building CreateBuildingForUser(string buildingType, int userId)
        {
            var user = FetchUserWithBuildings(userId);
            var building = ModelForType(buildingType);
            user.Country.Buildings.Add(building);
            _context.SaveChanges();
            return building;
        }

        private ApplicationUser FetchUserWithBuildings(int userId)
        {
            return _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Buildings)
                .Single(user => user.Id == userId);
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