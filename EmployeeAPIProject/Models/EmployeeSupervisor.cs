using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIProject.Models;

public class EmployeeSupervisor
{
    [Key]
    public Guid SupervisorId { get; set; }

    [Key]
    public Guid EmployeeId { get; set; }

    public string SupervisorType { get; set; }

    // Navigation Properties
    public Employee Employee { get; set; }
}
