using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services;

public interface IEmployeeStatusService
{
    IEnumerable<EmployeeStatus> Get();
    EmployeeStatus Get(Guid id);
    void Change(Guid id, Employee statusChangeRequest);
   
}
