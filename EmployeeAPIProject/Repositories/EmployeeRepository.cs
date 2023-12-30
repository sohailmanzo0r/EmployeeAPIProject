using EmployeeAPIProject.Data;
using EmployeeAPIProject.Migrations;
using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories
{
    public class EmployeeRepository : IEmployee, IDisposable
    {
        private readonly EmployeeDbContext _employeeDbContext;

       
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public void AddEmployee(  Employee addedemployee)
        {
            _employeeDbContext.Employees.Add(addedemployee);
            save();
        }
        public void deleteEmployee([FromRoute] Guid id)
        {
        _employeeDbContext.Employees.Remove(_employeeDbContext.Employees.Find(id));
                save();
            
        }
       public  IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _employeeDbContext.Employees
                               .Include(e => e.JobDescription)
                                 .Include(e => e.EmployeeStatus).ToList();
            return employees;
        }

        public  Employee GetEmployee( Guid id)
        {
            return _employeeDbContext.Employees
                                  .Include(e => e.JobDescription)
                                  .Include(e => e.EmployeeStatus)
                                 .FirstOrDefault(em => em.Id == id);         
        }
        public void UpdateEmployee(Guid id, Employee EmployeeUpdateRequest)
        {
            var existingEmployee = _employeeDbContext.Employees
                                    .Include(e => e.JobDescription)
                                 .Include(e => e.EmployeeStatus)
                                 .FirstOrDefault(em => em.Id == id);
            if (existingEmployee != null)
            {  
                //_employeeDbContext.Entry(existingEmployee).State = EntityState.Modified;
                _employeeDbContext.Entry(existingEmployee).CurrentValues.SetValues(EmployeeUpdateRequest);
                // Save the changes
                save();
            }
            else
            {
                throw new Exception("Employee Does not exist you are trying to update");
            }
        }

        public void save()
        {
            _employeeDbContext.SaveChanges();
        }
        public void Dispose()
        {
            _employeeDbContext?.Dispose();
        }

       
    }
}
