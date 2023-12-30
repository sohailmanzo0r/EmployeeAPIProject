using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public class JobDescriptionRepository : IJobDescription, IDisposable
    {
        private readonly EmployeeDbContext _jobdescriptiondbcontext;

        public JobDescriptionRepository(EmployeeDbContext jobdescriptiondbcontext)
        {
             _jobdescriptiondbcontext = jobdescriptiondbcontext;
        }
        public IEnumerable<JobDescription> GetJobDescriptions()
        {
            return _jobdescriptiondbcontext.JobDescription.ToList();
        }
        public JobDescription GetJobDescription(Guid jobId)
        {
            return _jobdescriptiondbcontext.JobDescription.FirstOrDefault(e=>e.JobId == jobId);
        }
        public void save()
        {
            _jobdescriptiondbcontext.SaveChanges();
        }
        public void Dispose()
        {
            _jobdescriptiondbcontext?.Dispose();
        }

       
    }
}
