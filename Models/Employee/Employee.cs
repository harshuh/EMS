using Azure.Core;

namespace EMS.Models.Employee
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required int EmployeeId { get; set; }
        public required string Role { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required int Phone {get; set;}
        public decimal? Salary { get; set; }

    }
}
