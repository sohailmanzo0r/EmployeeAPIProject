using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIProject.Models;

public class EmployeeSupervisor
{
    [Key]
    public Guid SupervisorId { get; set; }

    [Key]
    public Guid EmployeeId { get; set; }

    public SupervisorType SupervisorType { get; set; }

    // Navigation Properties
    public Employee Employee { get; set; }
}
public enum SupervisorType
{
    Internee=1,
    TeamLeader=2,
    Manager=3,
    DepartmentHead=4,
}