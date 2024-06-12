using System.ComponentModel.DataAnnotations;

namespace Loyalty_campaigns.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Loyality_member { get; set; } = false;
        public List<Purchase>? Purchases { get; set; }
    }
}
