using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories;

public class JobDescriptionRepository : IJobDescription, IDisposable
{
    private readonly DbContext _context;

    public JobDescriptionRepository(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<JobDescription> Get()
    {
        return _context.Set<JobDescription>().ToList();
    }

    public JobDescription Get(Guid jobId)
    {
        return _context.Set<JobDescription>().FirstOrDefault(e => e.JobId == jobId);
    }
    public bool Add(JobDescription addJob)
    {
        try
        {
            _context.Set<JobDescription>().Add(addJob);
            return save();
        }
        catch (Exception)
        {
            return false;
        }
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
