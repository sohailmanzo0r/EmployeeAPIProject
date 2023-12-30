 using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories
{
    public class EmployeeSupervisorRepository : IEmployeeSupervisor,IDisposable
    {
        private readonly EmployeeDbContext _employeesupervisordbcontext;

        public EmployeeSupervisorRepository(EmployeeDbContext employeesupervisordbcontext)
        {
           _employeesupervisordbcontext = employeesupervisordbcontext;
        }
        public void AddSupervisor(EmployeeSupervisor supervisor)
        {
            var supervisor1 = new EmployeeSupervisor
            {
                EmployeeId = supervisor.EmployeeId,
                SupervisorType = supervisor.SupervisorType
            };

            _employeesupervisordbcontext.EmployeeSupervisor.Add(supervisor1);
            _employeesupervisordbcontext.SaveChanges();
        }

        public IEnumerable<EmployeeSupervisor> GetSupervisors()
        {
            return _employeesupervisordbcontext.EmployeeSupervisor.ToList();
        }
        public void save()
        {
            _employeesupervisordbcontext.SaveChanges();
        }
        public void Dispose()
        {
            _employeesupervisordbcontext?.Dispose();
        }

       
    }
}
