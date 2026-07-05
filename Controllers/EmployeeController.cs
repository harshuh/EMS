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
            try
            {
                appdbcontext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return Conflict($"An employee with EmployeeId {employee.EmployeeId} already exists.");
            }

            return Created("api/employees/{id}", body);

        }

        // Find Employee By Employee ID
        [HttpGet]
        [Route("{employeeId:int}")]
        public IActionResult GetEmployeeByEmployeeID(int employeeId)
        {
            var data = appdbcontext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (data == null)
                return NotFound($"No employee found with EmployeeId {employeeId}");

            return Ok(data);
        }


        // Update Employee
        [HttpPut]

        [Route("{employeeId:int}")]
        public IActionResult UpdateEmployeeById(int employeeId , Employee employee)
        {
            var user = appdbcontext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (user == null)
            {
                return NotFound($"No employee found with EmployeeId {employeeId}");
            }

            user.EmployeeId = employee.EmployeeId;
            user.Role = employee.Role;
            user.Name = employee.Name;
            user.Email = employee.Email;
            user.Phone = employee.Phone;
            user.Salary = employee.Salary;

            appdbcontext.Employees.Update(user);

            try
            {
                appdbcontext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return Conflict($"An employee with EmployeeId {employee.EmployeeId} already exists.");
            }

            return Ok(user);
        }

        // Delete Emp using emp id 
        [HttpDelete]
        [Route("{employeeId:int}")]
        public IActionResult DeleteEmployeeById(int employeeId)
        {
            var user = appdbcontext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (user == null)
            {
                return NotFound($"Employee With this Id:{employeeId} not found");
            }

            appdbcontext.Employees.Remove(user);
            appdbcontext.SaveChanges();  

            return NoContent();
        }
    }
}