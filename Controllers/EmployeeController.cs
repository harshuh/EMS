using Azure.Core;
using EMS.Models.Employee;
using EMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext appdbcontext;

        public EmployeeController(AppDbContext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }

        // Get All the Employees
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var data = appdbcontext.Employees.ToList();

            return Ok(data);
        }

        // Add or insert the Employees
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            var body = new Employee()
            {
                EmployeeId = employee.EmployeeId,
                Role = employee.Role,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary
            };

            appdbcontext.Employees.Add(body);
            appdbcontext.SaveChanges();

            return Created("api/employees/{id}",body);


        }
    }
}