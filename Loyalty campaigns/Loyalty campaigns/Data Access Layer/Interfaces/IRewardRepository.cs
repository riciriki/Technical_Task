using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer.Interfaces
{
    public interface IRewardRepository
    {
        //add context
        public Task<Reward> AddRewardAsync(Reward newReward);
    }
}
