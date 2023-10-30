using Microsoft.EntityFrameworkCore;
using SqlApiDemo.Entities;

namespace SqlApiDemo.MyDB
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options):base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
