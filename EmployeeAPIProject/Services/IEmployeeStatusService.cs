using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeStatusService
    {
        IEnumerable<EmployeeStatus> GetEmployeeStatus();
        void ChangeStatus(Guid id, Employee statusChangeRequest);
       
    }
}
