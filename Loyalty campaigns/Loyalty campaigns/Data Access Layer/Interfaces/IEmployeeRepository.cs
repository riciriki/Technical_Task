using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<Employee> AddEmployee(Employee employee);
        public Task<Employee> FindByUsename(string username);
    }
}
