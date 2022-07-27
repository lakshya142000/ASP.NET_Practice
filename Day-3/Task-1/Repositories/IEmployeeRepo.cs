using WebApplication3.Models;
namespace WebApplication3.Repositories
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmployee();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee obj);
        void UpdateEmployee(Employee obj);
        void DeleteEmployee(int id);
        
    }
}
