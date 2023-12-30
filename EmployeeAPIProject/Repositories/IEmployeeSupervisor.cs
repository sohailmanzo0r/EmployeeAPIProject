using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployeeSupervisor
    {
        IEnumerable<EmployeeSupervisor> GetSupervisors();
        void AddSupervisor(EmployeeSupervisor supervisor);
        void save();
    }
}
