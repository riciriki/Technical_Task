using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer.Interfaces
{
    public interface IRewardService
    {
        public Task<Reward> AddRewardAsync(Reward newReward);
    }
}
