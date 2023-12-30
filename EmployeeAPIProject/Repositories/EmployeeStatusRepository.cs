using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public class EmployeeStatusRepository : IEmployeeStatus,IDisposable
    {
        private readonly EmployeeDbContext _statusDbContext;

        public EmployeeStatusRepository(EmployeeDbContext statusDbContext) {
            _statusDbContext = statusDbContext;
        }


        public IEnumerable<EmployeeStatus> GetEmployeeStatus()
        {
            return _statusDbContext.EmployeeStatus.ToList();
        }
        public void save()
        {
            _statusDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _statusDbContext?.Dispose();
        }

      
    }
}
