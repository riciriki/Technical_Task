using System.Text.Json.Serialization;

namespace Loyalty_campaigns.DTOs
{
    public class RewardDTO
    {
        
        public int Customer_id { get; set; }
        [JsonIgnore]
        public int Employee_id { get; set; }
    }
}
