using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeSupervisorService
    {
        IEnumerable<EmployeeSupervisor> GetSupervisors();
        void AddSupervisor(EmployeeSupervisor supervisor);
        
        
    }
}
