using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories
{
    public class EmployeeStatusRepository : IEmployeeStatus,IDisposable
    {
        private readonly DbContext _context;

        public EmployeeStatusRepository (DbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeStatus> Get()
        {
            return _context.Set<EmployeeStatus>().ToList();
        }

        public EmployeeStatus Get(Guid id)
        {
            return _context.Set<EmployeeStatus>().FirstOrDefault(e => e.StatusId == id);
        }
         
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
