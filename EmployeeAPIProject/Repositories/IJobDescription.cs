using EmployeeAPIProject.Models;

namespace EmployeeAPIProject.Repositories
{
    public interface IJobDescription
    {
        IEnumerable<JobDescription> GetJobDescriptions();
        void save();
    }
}
