using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories;

public interface IJobDescription
{
    IEnumerable<JobDescription> Get();
    JobDescription Get(Guid jobId);
    public bool Add(JobDescription addJob);
}
