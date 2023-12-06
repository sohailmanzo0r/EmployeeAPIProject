using EmployeeAPIProject.Data;

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
                    var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
                    var employees = dbContext.employees
                        .Where(e => e.StatusChangeDate.HasValue && e.StatusChangeDate <= DateTime.Now)
                        .ToList();

                    foreach (var employee in employees)
                    {

                        employee.status = employee.laterstatus; // Change status as needed
                                                       // Reset the status change date
                                                          // Handle other status change actions

                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }

}
