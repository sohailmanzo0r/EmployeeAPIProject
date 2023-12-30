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
        public EmployeeStatus GetEmployeeStatus(Guid id)
        {
            return _statusDbContext.EmployeeStatus.FirstOrDefault(e=>e.StatusId == id);
        }
        public void Dispose()
        {
            _statusDbContext?.Dispose();
        }

       
    }
}
