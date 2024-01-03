using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIProject.Models;

public class EmployeeStatus
{
    [Key]
    public Guid StatusId { get; set; }
    public Status StatusName { get; set; }

    // Navigation Property
    public List<Employee> Employees { get; set; }
}
