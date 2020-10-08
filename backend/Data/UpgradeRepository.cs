using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using backend.DTOs;
using System;
using System.Threading.Tasks;

namespace backend.Data
{
    public interface IUpgradeRepository
    {
        Task<IEnumerable<CountryUpgrade>> GetUpgradesForUser(int userId);
        Task<CountryUpgrade> GetUpgradeById(int upgradeId, int userId);
        Task<CountryUpgrade> CreateUpgradeForUser(UpgradeCreateDto upgrade, int userId);
        Task<IEnumerable<Upgrade>> GetUpgradeTypes();
    }

    public class UpgradeRepository : IUpgradeRepository
    {
        private readonly StrategyGameContext _context;

        public UpgradeRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CountryUpgrade>> GetUpgradesForUser(int userId)
        {
            var user = await FetchUserWithUpgrades(userId);
            return user.Country.Upgrades;
        }

        public async Task<CountryUpgrade> GetUpgradeById(int id, int userId)
        {
            var user = await FetchUserWithUpgrades(userId);
            foreach (var upgrade in user.Country.Upgrades)
            {
                if (upgrade.Id == id)
                {
                    return upgrade;
                }
            }
            return null;
        }

        public async Task<CountryUpgrade> CreateUpgradeForUser(UpgradeCreateDto upgrade, int userId)
        {
            var user = await FetchUserWithUpgrades(userId);
            var upgradeModel = await _context.Upgrades
               .Where(u => u.Name == upgrade.Name)
               .SingleOrDefaultAsync();

            var countryUpgrade = AddUpgradeToUser(upgradeModel, user);
            await _context.SaveChangesAsync();
            return countryUpgrade;
        }

        public async Task<IEnumerable<Upgrade>> GetUpgradeTypes()
        {
            return await _context.Upgrades.ToListAsync();
        }

        private async Task<ApplicationUser> FetchUserWithUpgrades(int userId)
        {
            return await _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Upgrades)
                    .ThenInclude(u => u.Upgrade)
                .SingleOrDefaultAsync(user => user.Id == userId);
        }

        private CountryUpgrade AddUpgradeToUser(Upgrade upgrade, ApplicationUser user)
        {
            foreach (var countryUpgrade in user.Country.Upgrades)
            {
                if (countryUpgrade.Upgrade == upgrade)
                {
                    throw new ArgumentException("Upgrade has been already researched");
                }
            }
            var cu = new CountryUpgrade { Upgrade = upgrade };
            user.Country.Upgrades.Add(cu);
            return cu;
        }
    }
}