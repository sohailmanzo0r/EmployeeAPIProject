using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeService
    {
        
          IEnumerable<EmployeeDTO> GetAllEmployees();
          IEnumerable<JobDescription> GetJobDescriptions();
          IEnumerable<EmployeeStatus> GetEmployeeStatus();
        IEnumerable<EmployeeSupervisor> GetSupervisors();


        void AddEmployee(Employee addedemployee);
         
        EmployeeDTO GetEmployee([FromRoute] Guid id);
         
        void UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest);
        
        void deleteEmployee(Guid id);
        
        Employee LoginUser(Login user);
       
        string calculateAge(string dob);
          string GenerateJwtToken(Employee user);
        void ChangeStatus(Guid id, Employee statusChangeRequest);
    }
}
