using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer.Interfaces
{
    public interface IPurchaseRepository
    {
        public List<Purchase> GetSuccessfulPurchasesCSVAsync();
    }
}
