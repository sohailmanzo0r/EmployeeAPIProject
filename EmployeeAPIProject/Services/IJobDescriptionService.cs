using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services
{
    public interface IJobDescriptionService
    {
        IEnumerable<JobDescription> GetJobDescriptions();
        JobDescription GetJobDescription(Guid jobId);
    }
}
