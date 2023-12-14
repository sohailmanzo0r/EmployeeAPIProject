using System.Text.Json.Serialization;

namespace EmployeeAPIProject.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
       public string DOB { get; set; }
        
        public Guid? JobId { get; set; }
        public JobDescription JobDescription { get; set; }

        public Guid? StatusId { get; set; }
        public EmployeeStatus? EmployeeStatus { get; set; }

        public List<EmployeeSupervisor> Supervisors { get; set; }
        public List<LoginLog> LoginLogs { get; set; }

      
    }
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
         public string Age { get; set; }
        public Guid? JobId { get; set; }
        public JobDescription JobDescription { get; set; }

        public Guid StatusId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public List<EmployeeSupervisor> Supervisors { get; set; }
        public List<LoginLog> LoginLogs { get; set; }
         

    }
    public enum Status
    {
        Active=1,
        Pending=2,
        Suspend=3,
        Terminate=4,
        Delete=5
    }
}
