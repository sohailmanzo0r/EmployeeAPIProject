using EmployeeAPIProject.Data;
using EmployeeAPIProject.Migrations;
using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories;

public class EmployeeRepository : IEmployee, IDisposable
{
    private readonly DbContext _context;

    public EmployeeRepository(DbContext context)
    {
        _context = context;
    }

    public bool Add(Employee addedEmployee)
    {
        try
        {
            _context.Set<Employee>().Add(addedEmployee);
            return save(); 
        }
        catch (Exception)
        {       
            return false;
        }
    }

    public IEnumerable<Employee> Get()
    {
        var employees = _context.Set<Employee>()
                            .Include(e => e.JobDescription)
                            .Include(e => e.EmployeeStatus).ToList();
        return employees;
    }
    public Employee Get(Guid id)
    {
        return _context.Set<Employee>()
                       .Include(e => e.JobDescription)
                       .Include(e => e.EmployeeStatus)
                       .FirstOrDefault(em => em.Id == id);
    }
    public bool Delete(Guid id)
    {
        var employee = _context.Set<Employee>().Find(id);
        if (employee != null)
        {
            _context.Set<Employee>().Remove(employee);
            return save();  
        }
        return false;
    }

    public bool Update(Guid id, Employee employeeUpdateRequest)
    {
        var existingEmployee = _context.Set<Employee>()
                                       .Include(e => e.JobDescription)
                                       .Include(e => e.EmployeeStatus)
                                       .FirstOrDefault(em => em.Id == id);

        if (existingEmployee != null)
        {
            _context.Entry(existingEmployee).CurrentValues.SetValues(employeeUpdateRequest);
            return save();  
        }
        return false;  
    }


    public bool save()
    {
         
        try
        {
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
             
            return false;
        }
    }
    public void Dispose()
    {
        _context?.Dispose();
    }

   
}
