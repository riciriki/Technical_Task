using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> AddEmployee(EmployeeDTO newEmployee, byte[] passwordHash, byte[] passworSalt);
        public Task<Employee> CheckEmployeeCredentials(string username);
    }
}
