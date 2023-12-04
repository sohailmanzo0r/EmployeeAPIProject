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
        //public EmployeeRepository( )
        //{
        //    _employeeDbContext = new EmployeeDbContext();
        //}

        public void AddEmployee(  Employee addedemployee)
        {
           
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
            return _employeeDbContext.employees.ToList();
             
        }

        public  Employee GetEmployee( Guid id)
        {
            return _employeeDbContext.employees.FirstOrDefault(em => em.Id == id);     
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
       private void save()
        {
            _employeeDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _employeeDbContext?.Dispose();
        }
    }
}
