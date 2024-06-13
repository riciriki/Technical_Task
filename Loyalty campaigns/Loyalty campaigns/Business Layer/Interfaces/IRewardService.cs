using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer.Interfaces
{
    public interface IRewardService
    {
        public Task<int> AddRewardAsync(RewardDTO newReward);
        public Task<List<Reward>> GetAllRewards();
    }
}
