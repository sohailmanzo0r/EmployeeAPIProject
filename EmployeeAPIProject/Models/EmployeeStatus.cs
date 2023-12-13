using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIProject.Models
{
    public class EmployeeStatus
    {
        [Key]
        public Guid StatusId { get; set; }
        public Status status { get; set; }
        public Status? laterstatus { get; set; }
        public string? StatusChangeChoice { get; set; }
        public DateTime? StatusChangeDate { get; set; }
        public string?  StatusChangeReason { get; set; }

        // Navigation Property
        public List<Employee> Employees { get; set; }
    }
}
