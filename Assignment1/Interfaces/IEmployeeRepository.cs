using Assignment1.Models;
using System.Numerics;

namespace Assignment1.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<List<Employee>> GetAllEmployee();        
        public Task<Employee> GetEmployeeById(string? Id);
        public Task<Employee> CreateEmployee(Employee employee);
        public Task<Employee> UpdateEmployee(Employee employee);
    }
}
