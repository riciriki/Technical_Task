using Loyalty_campaigns.Business_Layer.Interfaces;
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
        public async Task<ActionResult<List<Reward>>> CreateNewReward(Reward reward)
        {

            return Ok(await _rewardService.AddRewardAsync(reward));
        }
    }
}
