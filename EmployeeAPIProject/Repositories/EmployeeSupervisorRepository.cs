 using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories;

public class EmployeeSupervisorRepository : IEmployeeSupervisor,IDisposable
{
    private readonly DbContext _context;

    public EmployeeSupervisorRepository(DbContext context)
    {
        _context = context;
    }

    public bool Add(EmployeeSupervisor supervisor)
    {
        try
        {
            var supervisorToAdd = new EmployeeSupervisor
            {
                EmployeeId = supervisor.EmployeeId,
                SupervisorType = supervisor.SupervisorType
            };

            _context.Set<EmployeeSupervisor>().Add(supervisorToAdd);
            return save(); // Assuming 'save' returns a boolean
        }
        catch (Exception)
        {
            // Optionally log the exception details here
            return false;
        }
    }

    public IEnumerable<EmployeeSupervisor> Get()
    {
        return _context.Set<EmployeeSupervisor>().ToList();
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
