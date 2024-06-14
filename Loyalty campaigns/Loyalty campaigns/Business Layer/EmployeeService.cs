using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.Data_Access_Layer.Interfaces;
using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;

namespace Loyalty_campaigns.Business_Layer
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployee(EmployeeDTO newEmployee, byte[] passwordHash, byte[] passworSalt)
        {

            Employee employee = new Employee
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Username = newEmployee.Username,
                RoleId = 1,
                PasswordHash = passwordHash,
                PasswordSalt = passworSalt
            };
            return await _employeeRepository.AddEmployee(employee);
        }
        public async Task<Employee> CheckEmployeeCredentials(string username)
        {
            return await _employeeRepository.FindByUsename(username);
        }
    }
}
