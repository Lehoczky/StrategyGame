using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using backend.DTOs;
using System;

namespace backend.Data
{
    public interface IUpgradeRepository
    {
        IEnumerable<Upgrade> GetUpgradesForUser(int userId);
        Upgrade GetUpgradeById(int upgradeId, int userId);
        Upgrade CreateUpgradeForUser(UpgradeCreateDto upgrade, int userId);
    }

    public class UpgradeRepository : IUpgradeRepository
    {
        private readonly StrategyGameContext _context;

        public UpgradeRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Upgrade> GetUpgradesForUser(int userId)
        {
            var user = FetchUserWithUpgrades(userId);
            return user.Country.Upgrades;
        }

        public Upgrade GetUpgradeById(int id, int userId)
        {
            var user = FetchUserWithUpgrades(userId);
            foreach (var upgrade in user.Country.Upgrades)
                if (upgrade.Id == id)
                    return upgrade;
            return null;
        }

        public Upgrade CreateUpgradeForUser(UpgradeCreateDto upgrade, int userId)
        {
            var user = FetchUserWithUpgrades(userId);
            var upgradeModel = ModelForType(upgrade.Name);
            user.Country.Upgrades.Add(upgradeModel);
            _context.SaveChanges();
            return upgradeModel;
        }

        private ApplicationUser FetchUserWithUpgrades(int userId)
        {
            return _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Upgrades)
                .Single(user => user.Id == userId);
        }

        private Upgrade ModelForType(string type)
        {
            switch (type)
            {
                case "mudTractor":
                    return new Upgrade
                    {
                        Name = "iszaptraktor",
                        CoralBonus = 10,
                        DefenseBonus = 0,
                        AttackBonus = 0,
                        TaxBonus = 0
                    };
                case "mudCombine":
                    return new Upgrade
                    {
                        Name = "iszapkombájn",
                        CoralBonus = 15,
                        DefenseBonus = 0,
                        AttackBonus = 0,
                        TaxBonus = 0
                    };
                case "coralWall":
                    return new Upgrade
                    {
                        Name = "korallfal",
                        CoralBonus = 0,
                        DefenseBonus = 20,
                        AttackBonus = 0,
                        TaxBonus = 0
                    };
                case "sonarCannon":
                    return new Upgrade
                    {
                        Name = "szonár ágyú",
                        CoralBonus = 0,
                        DefenseBonus = 0,
                        AttackBonus = 20,
                        TaxBonus = 0
                    };
                case "undergroundMartialArts":
                    return new Upgrade
                    {
                        Name = "vízalatti harcművészetek",
                        CoralBonus = 0,
                        DefenseBonus = 10,
                        AttackBonus = 10,
                        TaxBonus = 0
                    };
                case "alchemy":
                    return new Upgrade
                    {
                        Name = "alkímia",
                        CoralBonus = 0,
                        DefenseBonus = 0,
                        AttackBonus = 0,
                        TaxBonus = 30
                    };
                default:
                    throw new ArgumentException("Invalid upgrade type");
            }
        }
    }
}