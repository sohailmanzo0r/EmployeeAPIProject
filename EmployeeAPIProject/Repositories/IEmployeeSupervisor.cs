using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployeeSupervisor
    {
        IEnumerable<EmployeeSupervisor> Get();
        void Add(EmployeeSupervisor supervisor);
 
    }
}
