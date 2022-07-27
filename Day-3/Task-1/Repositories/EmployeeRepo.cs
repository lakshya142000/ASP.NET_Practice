using WebApplication3.Models;
namespace WebApplication3.Repositories
{
    public class EmployeeRepo:IEmployeeRepo
    {
        EmployeeDbContext _context;
        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee obj = _context.Employees.Find(id);
            _context.Employees.Remove(obj);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> EList = _context.Employees.ToList();
            return EList;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee obj = _context.Employees.Find(id);
            return obj;
        }

        public void UpdateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            _context.SaveChanges();
        }
    }
}
