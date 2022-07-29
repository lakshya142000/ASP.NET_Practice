using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var empList = await _context.Employees.ToListAsync();
            return Ok(empList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var EmObj = await _context.Employees.FindAsync(id);

            if (EmObj != null)
                return Ok(EmObj);
            else
                return NotFound("Requested Product Id does not exists.");
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            await _context.Employees.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok("New Employee details have been added in database.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            await _context.SaveChangesAsync();
            return Ok("Employee's details are updated in database.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var EmObj = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(EmObj);
            await _context.SaveChangesAsync();
            return Ok("Employee's details are deleted from database.");
        }
    }
}
