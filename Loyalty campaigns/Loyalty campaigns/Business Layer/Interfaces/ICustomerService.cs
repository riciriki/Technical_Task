using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer.Interfaces
{
    public interface ICustomerService
    {
        public Task<Customer> GetCustomerById(int customerId);
    }
}
