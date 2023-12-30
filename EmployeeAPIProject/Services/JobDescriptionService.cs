using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;

namespace EmployeeAPIProject.Services
{
    public class JobDescriptionService : IJobDescriptionService
    {
        private readonly IJobDescription _jobDescription;

        public JobDescriptionService(IJobDescription jobDescription)
        {
             _jobDescription = jobDescription;
        }

        public JobDescription GetJobDescription(Guid jobId)
        {
            return _jobDescription.GetJobDescription(jobId);
        }

        public IEnumerable<JobDescription> GetJobDescriptions()
        {
          return  _jobDescription.GetJobDescriptions();
        }
    }
}
