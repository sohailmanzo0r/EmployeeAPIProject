using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories
{
    public class LoginLogsRepository : ILoginLogs, IDisposable
    {
        private readonly DbContext _context;

        public LoginLogsRepository(DbContext context)
        {
            _context = context;
        }

        public Employee LoginUser(Login user)
        {
            return _context.Set<Employee>()
                           .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Pwd);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

      
    }
}
