using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _customerRepository.GetCustomerById(customerId); 
        }
    }
}
