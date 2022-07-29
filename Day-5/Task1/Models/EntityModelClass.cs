using Microsoft.EntityFrameworkCore;
namespace WebApplication4.Models
{

    public class Employee
    {

        public int Id { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }
    }
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> option)
            : base(option)
        {

        }
    }
}
