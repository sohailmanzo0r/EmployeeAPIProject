using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeService
    {
         IEnumerable<EmployeeDTO> GetAllEmployees();
        void AddEmployee(Employee addedemployee);
        EmployeeDTO GetEmployee([FromRoute] Guid id);
        void UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest);
        void deleteEmployee(Guid id);
        string calculateAge(string dob);
    }
}
