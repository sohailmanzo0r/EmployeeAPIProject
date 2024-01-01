using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployeeStatus
    {
        IEnumerable<EmployeeStatus> Get ();
        EmployeeStatus Get(Guid id);
    }
}
