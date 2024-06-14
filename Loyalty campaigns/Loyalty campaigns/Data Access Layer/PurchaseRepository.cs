using Loyalty_campaigns.Data_Access_Layer.Context;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_campaigns.Data_Access_Layer
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DataContext _context;
        public PurchaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Purchase>> GetSuccessfulPurchasesCSVAsync()
        {
            var result = await _context.Purchases
                                       .Include(p => p.Customer)
                                       .ThenInclude(c => c.Reward)
                                       .Where(p => p.Customer.Reward != null && p.Date_created >= p.Customer.Reward.Date_created)
                                       .ToListAsync();
            return result;
        }
    }
}
