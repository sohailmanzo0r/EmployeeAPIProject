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

            var jobdescription = _employeeDbContext.JobDescription.Find(addedemployee.JobId);
            var status= _employeeDbContext.EmployeeStatus.Find(addedemployee.StatusId);
            addedemployee.EmployeeStatus = status;
            addedemployee.JobDescription = jobdescription;
            _employeeDbContext.employees.Add(addedemployee);
                   save();
             

        }

        

        public void deleteEmployee([FromRoute] Guid id)
        {
        _employeeDbContext.employees.Remove(_employeeDbContext.employees.Find(id));
                save();
            
        }
       public  IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _employeeDbContext.employees
                               .Include(e => e.JobDescription)
                                 .Include(e => e.EmployeeStatus).ToList();

            if (employees == null)
            {
                return null;
            }
            return employees;
        }

        public  Employee GetEmployee( Guid id)
        {
            return _employeeDbContext.employees
                                  .Include(e => e.JobDescription)
                                  .Include(e => e.EmployeeStatus)
                                 .FirstOrDefault(em => em.Id == id);     
        }

        public Employee LoginUser(Login user)
        {
              
            

            return _employeeDbContext.employees.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Pwd); 
            
        }

        public void UpdateEmployee( Guid id, Employee EmployeeUpdateRequest)
        {  
            if (_employeeDbContext.employees.Any(em => em.Id == id))
            {
                _employeeDbContext.Update(EmployeeUpdateRequest);
                save();
            }

        }
       public void save()
        {
            _employeeDbContext.SaveChanges();
        }
        public IEnumerable<JobDescription> GetJobDescriptions()
        {
            return _employeeDbContext.JobDescription.ToList();

        }

        public IEnumerable<EmployeeStatus> GetEmployeeStatus()
        {
            return _employeeDbContext.EmployeeStatus.ToList();
        }
        public IEnumerable<EmployeeSupervisor> GetSupervisors()
        {
            return _employeeDbContext.EmployeeSupervisor.ToList();
        }

        public void Dispose()
        {
            _employeeDbContext?.Dispose();
        }

        
    }
}
