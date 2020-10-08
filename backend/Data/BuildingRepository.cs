using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using System;
using System.Threading.Tasks;
using static backend.Helpers.Helpers;

namespace backend.Data
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<CountryBuilding>> GetBuildingsForUser(int userId);
        Task<CountryBuilding> GetBuildingById(int buildingId, int userId);
        Task<CountryBuilding> CreateBuildingForUser(string buildingType, int userId);
        Task<IEnumerable<Building>> GetBuildingsTypes();
    }

    public class BuildingRepository : IBuildingRepository
    {
        private readonly StrategyGameContext _context;

        public BuildingRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CountryBuilding>> GetBuildingsForUser(int userId)
        {
            var user = await FetchUserWithBuildings(userId);
            return user.Country.Buildings;
        }

        public async Task<CountryBuilding> GetBuildingById(int id, int userId)
        {
            var user = await FetchUserWithBuildings(userId);
            foreach (var building in user.Country.Buildings)
            {
                if (building.Id == id)
                {
                    return building;
                }
            }
            return null;
        }

        public async Task<CountryBuilding> CreateBuildingForUser(string buildingType, int userId)
        {
            var user = await FetchUserWithBuildings(userId);
            var building = await _context.Buildings
                .Where(b => b.Name == buildingType)
                .SingleOrDefaultAsync();

            Pay(user, building.Price);
            var countryBuilding = AddBuildingToUser(building, user);
            await _context.SaveChangesAsync();
            return countryBuilding;
        }

        public async Task<IEnumerable<Building>> GetBuildingsTypes()
        {
            return await _context.Buildings.ToListAsync();
        }

        private async Task<ApplicationUser> FetchUserWithBuildings(int userId)
        {
            return await _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Buildings)
                    .ThenInclude(buildings => buildings.Building)
                .SingleOrDefaultAsync(user => user.Id == userId);
        }

        private CountryBuilding AddBuildingToUser(Building building, ApplicationUser user)
        {
            CountryBuilding cb = null;
            foreach (var countryBuilding in user.Country.Buildings)
            {
                if (countryBuilding.Building == building)
                {
                    cb = countryBuilding;
                }
            }
            if (cb != null)
            {
                cb.Count += 1;
            }
            else
            {
                cb = new CountryBuilding { Count = 1, Building = building };
                user.Country.Buildings.Add(cb);
            }
            return cb;
        }
    }
}