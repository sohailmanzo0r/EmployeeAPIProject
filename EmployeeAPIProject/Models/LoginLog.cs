using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIProject.Models
{
    public class LoginLog
    {
        [Key]
        public Guid LogId { get; set; }

        // Foreign Key
        public Guid EmployeeId { get; set; }

        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }

        // Navigation Property
        public Employee Employee { get; set; }
    }
}
