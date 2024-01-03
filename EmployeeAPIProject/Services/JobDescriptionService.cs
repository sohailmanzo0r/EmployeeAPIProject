using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;

namespace EmployeeAPIProject.Services;

public class JobDescriptionService : IJobDescriptionService
{
    private readonly IJobDescription _jobDescription;

    public JobDescriptionService(IJobDescription jobDescription)
    {
         _jobDescription = jobDescription;
    }

    public void Add(JobDescription addJob)

    {
        addJob.JobId = new Guid();
           _jobDescription.Add(addJob);
    }

    public JobDescription Get(Guid jobId)
    {
        return _jobDescription.Get(jobId);
    }

    public IEnumerable<JobDescription> Get()
    {
      return  _jobDescription.Get();
    }
}
