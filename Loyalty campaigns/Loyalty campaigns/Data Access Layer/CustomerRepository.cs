using Loyalty_campaigns.Data_Access_Layer.Context;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_campaigns.Data_Access_Layer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;  
        }
        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _context.Customers.Where(c => c.Id == customerId).FirstOrDefaultAsync();
        }
    }
}
