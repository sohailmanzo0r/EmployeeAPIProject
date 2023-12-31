using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Repositories
{
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


        private void save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

       
    }
}
