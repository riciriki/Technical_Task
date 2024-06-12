using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepositry;

        public RewardService(IRewardRepository rewardRepository)
        {
                _rewardRepositry = rewardRepository;
        }
        public async Task<Reward> AddRewardAsync(Reward newReward)
        {
            newReward.Date_created = DateTime.Now;
            return  await _rewardRepositry.AddRewardAsync(newReward);
        }
    }
}
