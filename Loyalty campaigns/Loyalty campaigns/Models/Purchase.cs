using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Loyalty_campaigns.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date_created { get; set; }
        [ForeignKey("Customer")]
        public int Customer_id { get; set; }
        public Customer Customer { get; set; }
    }
}
