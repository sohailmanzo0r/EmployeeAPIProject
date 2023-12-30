using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeStatusService
    {
        IEnumerable<EmployeeStatus> GetEmployeeStatus();
        EmployeeStatus GetEmployeeStatus(Guid id);
        void ChangeStatus(Guid id, Employee statusChangeRequest);
       
    }
}
