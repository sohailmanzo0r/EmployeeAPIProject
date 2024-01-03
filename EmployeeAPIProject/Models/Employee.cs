using System.Text.Json.Serialization;
namespace EmployeeAPIProject.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public long Salary { get; set; }
    public string Department { get; set; }
    public string Password { get; set; }
   public DateTime DOB { get; set; }
    public Status? LaterStatus { get; set; }
    public string? StatusChangeChoice { get; set; }
    public DateTime? StatusChangeDate { get; set; }
    public string? StatusChangeReason { get; set; }

    public Guid JobId { get; set; }
    public JobDescription JobDescription { get; set; }

    public Guid StatusId { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; }

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
    public DateTime DOB { get; set; }
    public Status? LaterStatus { get; set; }
    public string? StatusChangeChoice { get; set; }
    public DateTime? StatusChangeDate { get; set; }
    public string? StatusChangeReason { get; set; }
    
    public Guid JobId { get; set; }

    public JobDescription JobDescription { get; set; }

    public Guid StatusId { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; }
    public List<EmployeeSupervisor> Supervisors { get; set; }
    public List<LoginLog> LoginLogs { get; set; }
    public string Age {
        get
        {
            return calculateAge(this.DOB);
        }
    }
    public string calculateAge(DateTime dob)
    {
        DateTime dateOfBirth = dob;


        DateTime currentDate = DateTime.Now;

        TimeSpan difference = currentDate.Subtract(dateOfBirth);

        // This is to convert the timespan to datetime object
        DateTime age = DateTime.MinValue + difference;

        // Min value is 01/01/0001
        // Actual age is say 24 yrs, 9 months and 3 days represented as timespan
        // Min Valye + actual age = 25 yrs , 10 months and 4 days.
        // subtract our addition or 1 on all components to get the actual date.

        int ageInYears = age.Year - 1;
        int ageInMonths = age.Month - 1;
        int ageInDays = age.Day - 1;

        return " Year " + ageInYears + ",Months " + ageInMonths + " ,Days " + ageInDays;
    }



}
public enum Status
{
    Active=1,
    InActive=2,
    OnLeave=3,
    Terminate=4
}
