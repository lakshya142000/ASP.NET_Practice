using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo repository)
        {
            _employeeRepo = repository;
        }
        public IActionResult Index()
        {
            List<Employee> EList = _employeeRepo.GetAllEmployee();
            return View(EList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _employeeRepo.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _employeeRepo.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _employeeRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
