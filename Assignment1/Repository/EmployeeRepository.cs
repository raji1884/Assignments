using Assignment1.Data;
using Assignment1.Interfaces;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Assignment1.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await dbSet.AddAsync(employee);
            await SaveAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            IQueryable<Employee> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(string id)
        {
            IQueryable<Employee> query = dbSet;
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _db.Employee.Update(employee);
            await _db.SaveChangesAsync();
            return employee;
        }
    }
}
