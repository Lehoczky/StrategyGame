using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using System;
using backend.DTOs;

namespace backend.Data
{
    public interface IUnitRepository
    {
        IEnumerable<Unit> GetUnitsForUser(int userId);
        void CreateUnitsForUser(UnitCreateDto units, int userId);
    }

    public class UnitRepository : IUnitRepository
    {
        private readonly StrategyGameContext _context;

        public UnitRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Unit> GetUnitsForUser(int userId)
        {
            var user = FetchUserWithUnits(userId);
            return user.Country.Units;
        }

        public Unit GetUnitById(int id, int userId)
        {
            var user = FetchUserWithUnits(userId);
            foreach (var unit in user.Country.Units)
                if (unit.Id == id)
                    return unit;
            return null;
        }

        public void CreateUnitForUser(Unit unit, int userId)
        {
            var user = FetchUserWithUnits(userId);
            user.Country.Units.Add(unit);
            _context.SaveChanges();
        }

        private ApplicationUser FetchUserWithUnits(int userId)
        {
            return _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Units)
                .Single(user => user.Id == userId);
        }

        public void CreateUnitsForUser(UnitCreateDto units, int userId)
        {
            var user = FetchUserWithUnits(userId);
            for (int _ = 0; _ < units.Count; _++)
            {
                var unit = ModelForType(units.Name);
                user.Country.Units.Add(unit);
            }
            _context.SaveChanges();
        }

        private ApplicationUser FetchUserWithUnits(int userId)
        {
            return _context.Users
                .Include(user => user.Country)
                    .ThenInclude(country => country.Units)
                .Single(user => user.Id == userId);
        }

        private Unit ModelForType(string type)
        {
            switch (type)
            {
                case "attackSeal":
                    return new Unit
                    {
                        Name = "rohamfóka",
                        Price = 50,
                        Attack = 6,
                        Defense = 2,
                        CostPerTurn = 1,
                        CoralPerTurn = 1
                    };
                case "battleSeaHorse":
                    return new Unit
                    {
                        Name = "csatacsikó",
                        Price = 50,
                        Attack = 2,
                        Defense = 6,
                        CostPerTurn = 1,
                        CoralPerTurn = 1
                    };
                case "laserShark":
                    return new Unit
                    {
                        Name = "lézercápa",
                        Price = 100,
                        Attack = 5,
                        Defense = 5,
                        CostPerTurn = 3,
                        CoralPerTurn = 2
                    };
                default:
                    throw new ArgumentException("Invalid unit type");
            }
        }
    }
}