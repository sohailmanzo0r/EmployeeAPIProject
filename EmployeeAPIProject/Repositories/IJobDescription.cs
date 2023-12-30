using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public interface IJobDescription
    {
        IEnumerable<JobDescription> GetJobDescriptions();
        JobDescription GetJobDescription(Guid jobId);
        void save();
    }
}
