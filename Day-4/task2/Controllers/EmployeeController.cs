using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repositories;
using log4net;
using WebApplication3.Filter;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo repository,ILogger<HomeController> logger)
        {
            _employeeRepo = repository;
            _logger = logger;
        }
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Index()
        {
            _logger.LogInformation("Index Action is Processed.");
            List<Employee> EList = _employeeRepo.GetAllEmployee();
            return View(EList);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create()
        {
            _logger.LogInformation("Create Action is Processed.");

            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create(Employee obj)
        {
            _logger.LogInformation("Create Action is completed.");
            _employeeRepo.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }


        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Edit Action is Processed.");
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(Employee obj)
        {
            _logger.LogInformation("Create Action is completed.");

            _employeeRepo.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete Action is Processed.");
            Employee obj = _employeeRepo.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult DeleteConfirm(int id)
        {
            _logger.LogInformation("Delete confirm Action is Processed.");
            _employeeRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetDetailsByDep()
        {
            _logger.LogInformation("Get details by dep Action is Processed.");
            return View();
        }
        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetDetailsByDep(int deptNo)
        {
            _logger.LogInformation("Get details by dep Action is completed.");


            IEnumerable<Employee> obj =_employeeRepo.GetEmployeeByDeptNo(deptNo);
            ViewBag.RequestType = Request.Method;
            return View(obj);
        }
        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetDetailsByjob()
        {
            _logger.LogInformation("Get details by job Action is Processed.");

            return View();
        }
        [HttpPost]
        public IActionResult GetDetailsByJob(string job)
        {
            _logger.LogInformation("Get details by Job Action is completed.");


            IEnumerable<Employee> obj = _employeeRepo.GetEmployeeByJob(job);
            ViewBag.RequestType = Request.Method;
            return View(obj);
        }
    }
}
