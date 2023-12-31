using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Services
{
    // Add a BackgroundService (can be added to Startup.cs)
    public class StatusChangeBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public StatusChangeBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
                                employee.StatusChangeDate = null;                                          // Reset the status change date                                             // Handle other status change actio
                                dbContext.SaveChanges();
                            }
                        }
                    }
                }
            }
        }
    }





}
