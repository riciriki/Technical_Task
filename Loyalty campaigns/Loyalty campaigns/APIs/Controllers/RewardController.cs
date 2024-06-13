using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<int>> CreateNewReward([FromBody] RewardDTO reward)
        {
            var result = await _rewardService.AddRewardAsync(reward);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Reward>>> GetAllRewards() 
        {
            return await _rewardService.GetAllRewards();
        }

    }
}
