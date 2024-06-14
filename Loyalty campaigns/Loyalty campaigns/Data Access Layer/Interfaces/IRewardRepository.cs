using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer.Interfaces
{
    public interface IRewardRepository
    {
        //add context
        public Task<int> AddRewardAsync(Reward newReward);
        public Task<List<Reward>> GetAllRewards();
        public Task<int> VerifyDailyRewardLimit(int employeeId);
    }
}
