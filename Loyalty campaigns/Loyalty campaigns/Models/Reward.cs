namespace Loyalty_campaigns.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public int Agent_id { get; set; }
        public DateTime Date_created;
    }
}
