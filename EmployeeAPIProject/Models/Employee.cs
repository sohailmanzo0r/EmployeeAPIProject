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
       
        public Status status { get; set; }
        public Status laterstatus { get; set; }
        public string StatusChangeChoice { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        public string StatusChangeReason { get; set; }
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
        public Status status { get; set; }
        public Status? laterstatus { get; set; }
        public string StatusChangeChoice { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        public string StatusChangeReason { get; set; }

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
