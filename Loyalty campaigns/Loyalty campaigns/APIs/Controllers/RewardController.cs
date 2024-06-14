using Loyalty_campaigns.Business_Layer.Exceptions;
using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Loyalty_campaigns.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;
        
        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<int>> CreateNewReward([FromBody] RewardDTO reward)
        {
            reward.Employee_id = 1;
            // reward.Employee_id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (!await _rewardService.VerifyDailyRewardLimit(reward.Employee_id)) 
            {
                var result = await _rewardService.AddRewardAsync(reward);
                return Ok(result);
            }
            throw new LimitExceededException("You exceeded today's limit.");
            
           
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Reward>>> GetAllRewards() 
        {
            return await _rewardService.GetAllRewards();
        }

    }
}
