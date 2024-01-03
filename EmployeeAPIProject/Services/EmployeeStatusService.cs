using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Services;

public class EmployeeStatusService : BackgroundService, IEmployeeStatusService
{
    private readonly IEmployeeStatus _employeeStatusRepository;
    private readonly IEmployee _employeeRepository;
    private readonly IServiceProvider _serviceProvider;
    public EmployeeStatusService(IEmployeeStatus employeeStatusRepository,IEmployee employeeRepository, IServiceProvider serviceProvider)
    {
        _employeeStatusRepository = employeeStatusRepository;
        _employeeRepository = employeeRepository;
        _serviceProvider = serviceProvider;
    }

    public void Change(Guid id, Employee emp)
    {
        var employee = _employeeRepository.Get(id);
        if (employee != null)
        {
            employee.EmployeeStatus.StatusId = emp.EmployeeStatus.StatusId;
            employee.StatusChangeChoice = emp.StatusChangeChoice;
            employee.StatusChangeDate = emp.StatusChangeChoice.ToLower() == "later"
                ? emp.StatusChangeDate
                : DateTime.Now;
            // Store the reason and additional property
            employee.StatusChangeReason = emp.StatusChangeReason;
            employee.StatusId = emp.StatusId;
            _employeeRepository.save();
        }

    }

    public IEnumerable<EmployeeStatus> Get()
    {
        return _employeeStatusRepository.Get();
    }

    public EmployeeStatus Get(Guid id)
    {
        return _employeeStatusRepository.Get(id);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Adjust the delay as needed

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
                var employees = dbContext.Set<Employee>()
          .Where(e => e.StatusChangeDate.HasValue && e.StatusChangeDate <= DateTime.Now)
                .ToList();
                if (employees != null)
                {
                    foreach (var employee in employees)
                    {

                        var emp = dbContext.Set<EmployeeStatus>().FirstOrDefault(e => e.StatusName == employee.LaterStatus);
                        if (emp != null)
                        {
                            employee.StatusId = emp.StatusId; // Change status as needed
                            employee.StatusChangeDate = null; // Reset the status change date                                            
                            dbContext.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
