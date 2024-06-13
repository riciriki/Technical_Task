using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public List<Purchase> GetSuccessfulPurchasesCSVAsync()
        {
            return new List<Purchase>{

                           new Purchase { Id=1, Customer_id=1, Date_created=DateTime.UtcNow },
                           new Purchase { Id=2, Customer_id=1, Date_created=DateTime.UtcNow}
                       };
        }
    }
}
