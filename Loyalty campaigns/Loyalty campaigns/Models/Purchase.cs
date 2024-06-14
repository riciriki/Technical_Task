using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Loyalty_campaigns.Models
{
    public class Purchase
    {
       
        public int Id { get; set; }
        public DateTime Date_created { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
