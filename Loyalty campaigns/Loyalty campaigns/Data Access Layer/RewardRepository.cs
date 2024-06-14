using Loyalty_campaigns.Data_Access_Layer.Context;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_campaigns.Data_Access_Layer
{
    public class RewardRepository : IRewardRepository
    {
        private readonly DataContext _context;
        public RewardRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddRewardAsync(Reward newReward)
        {
            _context.Rewards.Add(newReward);
            await _context.SaveChangesAsync();
            return newReward.Id;
        }

        public async Task<List<Reward>> GetAllRewards()
        {
            return await _context.Rewards.ToListAsync();
        }

        public async Task<int> VerifyDailyRewardLimit(int employeeId)
        {
            var rewardCount =   await _context.Rewards
                                .Where(r => r.EmployeeId == employeeId)
                                .GroupBy(r => r.Date_created.Date)
                                .Select(g => new { Date = g.Key, Count = g.Count() })
                                .CountAsync();
            return rewardCount;

        }
    }
}
