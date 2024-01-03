using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories;

public interface IEmployeeSupervisor
{
    IEnumerable<EmployeeSupervisor> Get();
    public bool Add(EmployeeSupervisor supervisor);


}
