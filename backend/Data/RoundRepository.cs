using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using backend.Models;
using System.Threading.Tasks;
using Hangfire;
using System;

namespace backend.Data
{
    public interface IRoundRepository
    {
        Task<Round> GetRound();
        void startGame();
    }

    public class RoundRepository : IRoundRepository
    {
        private readonly StrategyGameContext _context;

        public RoundRepository(StrategyGameContext context)
        {
            _context = context;
        }

        public async Task<Round> GetRound()
        {
            return await _context.Rounds.SingleAsync();
        }

        public void startGame()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Round started"), Cron.Hourly);
        }
    }
}