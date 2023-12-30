using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;

namespace EmployeeAPIProject.Services
{
    public class EmployeeSupervisorService : IEmployeeSupervisorService
    {
        private readonly IEmployeeSupervisor _employeeSupervisor;

        public EmployeeSupervisorService(IEmployeeSupervisor employeeSupervisor)
        {
            _employeeSupervisor = employeeSupervisor;
        }
        public void AddSupervisor(EmployeeSupervisor supervisor)
        {
            supervisor.SupervisorId = new Guid();
            _employeeSupervisor.AddSupervisor(supervisor);
            _employeeSupervisor.save();
        }

        public IEnumerable<EmployeeSupervisor> GetSupervisors()
        {
            return _employeeSupervisor.GetSupervisors();
        }
    }
}
