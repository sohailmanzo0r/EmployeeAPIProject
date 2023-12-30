using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services
{
    public interface ILoginLogsService
    {
        Employee LoginUser(Login user);
        public string GenerateJwtToken(Employee user);
    }
}
