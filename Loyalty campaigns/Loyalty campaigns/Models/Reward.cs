using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_campaigns.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public DateTime Date_created { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
