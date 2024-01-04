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
        if (supervisor == null)
            return false;
        try
        {     // Check if the supervisor relationship already exists
            bool exists = _context.Set<EmployeeSupervisor>().Any(es => es.EmployeeId == supervisor.EmployeeId &&
            es.SupervisorId == supervisor.SupervisorId);
            if (!exists)
            { _context.Set<EmployeeSupervisor>().Add(supervisor);
                return save();}
            else
            { return false;}
        }
        catch (Exception)
        {
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
        { return false;}
    }
    public void Dispose()
    {
        _context?.Dispose();
    }

   
}
