using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories;

public interface ILoginLogs
{
    Employee LoginUser(Login user);
    
}
