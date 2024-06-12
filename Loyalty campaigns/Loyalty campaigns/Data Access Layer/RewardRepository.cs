using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer
{
    public class RewardRepository : IRewardRepository
    {
        public async Task<Reward> AddRewardAsync(Reward newReward)
        {
            return newReward;
        }
    }
}
