using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_campaigns.Models
{
    public class Reward
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date_created { get; set; }
        public int Customer_id { get; set; }
       // public Customer Customer;
        [ForeignKey("Employee")]
        public int Employee_id { get; set; }
        public Employee Employee { get; set; }
    }
}
