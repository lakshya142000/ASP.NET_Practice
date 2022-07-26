using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager Context = new EmployeeManager();
        public IActionResult Index()
        {
            List<Employee> employees = Context.GetData();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid == true)
            {
                
                Context.addEmployee(obj);
                return RedirectToAction("Index");

            }
            else
            {

                ViewBag.RequestType = Request.Method;
                ViewBag.ErrorMessage = "Invalid data";
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            Employee obj = Context.GetByEmpNo(id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = Context.GetByEmpNo(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid == true)
            {
                
                Context.UpdateDetails(obj);
                return RedirectToAction("Index");

            }
            else
            {

                ViewBag.RequestType = Request.Method;
                ViewBag.ErrorMessage = "Invalid data";
                return View();
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = Context.GetByEmpNo(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Context.DeleteEmp(id);
            return RedirectToAction("Index");


        }
    }
}
