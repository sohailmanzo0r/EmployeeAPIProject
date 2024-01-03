using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIProject.Models;

public class JobDescription
{

    [Key]
    public Guid JobId { get; set; }
    public string JobTitle { get; set; }
    public string Responsibilities { get; set; }

    // Navigation Property
    public List<Employee> Employees { get; set; }
}
