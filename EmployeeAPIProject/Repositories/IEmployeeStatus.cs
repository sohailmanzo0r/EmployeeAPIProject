using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployeeStatus
    {
        IEnumerable<EmployeeStatus> GetEmployeeStatus();
        EmployeeStatus GetEmployeeStatus(Guid id);
        void save();
    }
}
