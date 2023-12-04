﻿using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployee :IDisposable
    {
        // Get all employees
        public IEnumerable<Employee> GetAllEmployees();
        //add new employee
          void AddEmployee(Employee addedemployee);
        //get employee by id
          Employee GetEmployee([FromRoute] Guid id);
        //update employee by id
          void UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest);
        //Delete employee by id
          void deleteEmployee(Guid id);
        //login user method
         Employee LoginUser(Login user);
        // age calculation method
         
       


    }
}