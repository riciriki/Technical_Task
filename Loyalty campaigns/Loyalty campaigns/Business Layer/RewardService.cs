﻿using Loyalty_campaigns.Business_Layer.Exceptions;
using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepositry;
        private readonly ICustomerRepository _customerRepositry;

        public RewardService(IRewardRepository rewardRepository, ICustomerRepository customerRepositry)
        {
                _rewardRepositry = rewardRepository;
                _customerRepositry = customerRepositry;
        }

        public async Task<int> AddRewardAsync(RewardDTO newReward)
        {
            Reward reward = new Reward
            {
                EmployeeId = newReward.Employee_id,
                CustomerId = newReward.Customer_id,
                Date_created = DateTime.UtcNow
            };
            // return (List<RewardDTO>)(await _rewardRepositry.AddRewardAsync(reward)).Select(u => new RewardDTO { Customer_id = u.Customer_id, Employee_id = u.Employee_id });
            return await _rewardRepositry.AddRewardAsync(reward);
        }

        public async Task<List<Reward>> GetAllRewards()
        {
           return await _rewardRepositry.GetAllRewards();
        }

        public async Task<bool> VerifyDailyRewardLimit(int employeeId) 
        {

            int rewardcount = await _rewardRepositry.VerifyDailyRewardLimit(employeeId);
            if (rewardcount >= 5) return true;
            return false;
        }
        public async Task<bool> IsCustomerLoyaltyMember(int customerId) 
        {
            Customer customer = await _customerRepositry.GetCustomerById(customerId);
            if (!customer.Loyality_member)
                return false;
            return true;
        }
    }
}
