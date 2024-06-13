using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;
using System.Text;

namespace Loyalty_campaigns.Business_Layer
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public string GetSuccessfulPurchasesCSVAsync()
        {
            List<Purchase> purchases = _purchaseRepository.GetSuccessfulPurchasesCSVAsync();
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Date_created,Customer_id");
            foreach (var purchase in purchases)
            {
                csvBuilder.AppendLine($"{purchase.Id},{purchase.Date_created},{purchase.Customer_id}");
            }

            var filePath = Path.Combine(Path.GetTempPath(), "products.csv");
            File.WriteAllText(filePath, csvBuilder.ToString());

            return filePath;
        }
    }
}
