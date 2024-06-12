using System.ComponentModel.DataAnnotations;

namespace Loyalty_campaigns.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public List<Reward> Rewards { get; set; }
    }
}
