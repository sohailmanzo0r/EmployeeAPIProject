using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public class LoginLogsRepository : ILoginLogs, IDisposable
    {
        private readonly EmployeeDbContext _loginlogdbcontext;

        public LoginLogsRepository(EmployeeDbContext loginlogdbcontext)
        {
            _loginlogdbcontext = loginlogdbcontext;
        }
        public Employee LoginUser(Login user)
        {
            return _loginlogdbcontext.Employees.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Pwd);
        }
        public void save()
        {
            _loginlogdbcontext.SaveChanges();
        }
        public void Dispose()
        {
            _loginlogdbcontext?.Dispose();
        }

      
    }
}
