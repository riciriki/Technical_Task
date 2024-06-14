using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetCustomerById(int customerId);
    }
}
