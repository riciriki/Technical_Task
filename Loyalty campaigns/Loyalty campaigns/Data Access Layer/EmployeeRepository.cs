using Loyalty_campaigns.Data_Access_Layer.Context;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Data_Access_Layer
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        
    }
}
