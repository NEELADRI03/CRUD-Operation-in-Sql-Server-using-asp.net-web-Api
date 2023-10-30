using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SqlApiDemo.Entities;
using SqlApiDemo.Models;
using SqlApiDemo.MyDB;

namespace SqlApiDemo.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public readonly MyDBContext _dbContext;

        public EmployeeRepo(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            //return "Employee Added";
        }

        public string DeleteEmployee(int id)
        {
            _dbContext.Remove(_dbContext.Employees.Single(a=> a.Id == id));
            _dbContext.SaveChanges();
            return "Deleted";
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _dbContext.Employees.Where(c=>c.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public void UpdateEmployee(Employee employee)
        {
           _dbContext.Employees.Update(employee);
            
        }

        public async Task<bool> SaveAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }
    }
}
