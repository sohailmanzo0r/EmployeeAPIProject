using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployeeStatus
    {
        IEnumerable<EmployeeStatus> GetEmployeeStatus();
        void save();
    }
}
