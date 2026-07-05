using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace EMS.Models.Employee
{
    [Index(nameof(EmployeeId), IsUnique = true)]
    public class Employee
    {
        public Guid Id { get; set; }
        public required int EmployeeId { get; set; }
        public required string Role { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required long Phone {get; set;}
        public decimal? Salary { get; set; }

    }
}
