using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeService
    {
        // Get all employees
        public IEnumerable<EmployeeDTO> GetAllEmployees();
        //add new employee
        void AddEmployee(Employee addedemployee);
        //get employee by id
        EmployeeDTO GetEmployee([FromRoute] Guid id);
        //update employee by id
        void UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest);
        //Delete employee by id
        void deleteEmployee(Guid id);
        //login user method
        Employee LoginUser(Login user);
        // age calculation method
        string calculateAge(string dob);
        public void ChangeStatus(Guid id, Employee statusChangeRequest);
    }
}
