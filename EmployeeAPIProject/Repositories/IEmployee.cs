using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployee :IDisposable
    {
        // Get all employees
          IEnumerable<Employee> GetAllEmployees();
          IEnumerable<JobDescription> GetJobDescriptions();
          IEnumerable<EmployeeStatus> GetEmployeeStatus();
          IEnumerable<EmployeeSupervisor> GetSupervisors();
        void AddSupervisor(SupervisorDTO supervisorDTO);
        void AddEmployee(Employee addedemployee);
          Employee GetEmployee([FromRoute] Guid id);
        void UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest);
          void deleteEmployee(Guid id);
        //login user method
         Employee LoginUser(Login user);

        
          void save();





    }
}
