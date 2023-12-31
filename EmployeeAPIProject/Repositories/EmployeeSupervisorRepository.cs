 using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories
{
    public class EmployeeSupervisorRepository : IEmployeeSupervisor,IDisposable
    {
        private readonly DbContext _context;

        public EmployeeSupervisorRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(EmployeeSupervisor supervisor)
        {
            var supervisor1 = new EmployeeSupervisor
            {
                EmployeeId = supervisor.EmployeeId,
                SupervisorType = supervisor.SupervisorType
            };

            _context.Set<EmployeeSupervisor>().Add(supervisor1);
            save();
        }

        public IEnumerable<EmployeeSupervisor> Get()
        {
            return _context.Set<EmployeeSupervisor>().ToList();
        }
        private void save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

       
    }
}
