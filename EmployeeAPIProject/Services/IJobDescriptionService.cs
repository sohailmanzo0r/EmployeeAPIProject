using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Services;

public interface IJobDescriptionService
{
    IEnumerable<JobDescription> Get();
    JobDescription Get(Guid jobId);
    public void Add(JobDescription addJob);
}
