using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services;

public interface IEmployeeSupervisorService
{
    IEnumerable<EmployeeSupervisor> Get();
    void Add(EmployeeSupervisor supervisor);
    
    
}
