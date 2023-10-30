using SqlApiDemo.Entities;
using SqlApiDemo.Models;

namespace SqlApiDemo.Services
{
    public interface IEmployeeRepo
    {
        void AddEmployee(Employee employee);
        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<Employee>> GetEmployees();
        void UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);
        Task<bool> SaveAsync();

    }
}
