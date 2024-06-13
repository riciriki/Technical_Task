using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer.Interfaces
{
    public interface IPurchaseService
    {
        public string GetSuccessfulPurchasesCSVAsync();
    }
}
