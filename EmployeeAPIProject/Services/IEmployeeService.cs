using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeService
    {
        
          IEnumerable<EmployeeDTO> GetAllEmployees();
          IEnumerable<JobDescription> GetJobDescriptions();
          IEnumerable<EmployeeStatus> GetEmployeeStatus();
       
        void AddEmployee(Employee addedemployee);
         
        EmployeeDTO GetEmployee([FromRoute] Guid id);
         
        void UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest);
        
        void deleteEmployee(Guid id);
        
        Employee LoginUser(Login user);
       
        string calculateAge(string dob);
        public string GenerateJwtToken(Employee user);
        public void ChangeStatus(Guid id, EmployeeStatus statusChangeRequest);
    }
}
