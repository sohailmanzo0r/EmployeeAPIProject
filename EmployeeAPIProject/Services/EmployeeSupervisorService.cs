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
        public void Add(EmployeeSupervisor supervisor)
        {
            supervisor.SupervisorId = new Guid();
            _employeeSupervisor.Add(supervisor);
            
        }

        public IEnumerable<EmployeeSupervisor> Get()
        {
            return _employeeSupervisor.Get();
        }
    }
}
