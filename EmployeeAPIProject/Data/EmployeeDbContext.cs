using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Data
{
    public class EmployeeDbContext:DbContext
    {
       
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) { }
      public  DbSet<Employee> employees {  get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<EmployeeSupervisor> EmployeeSupervisors { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobDescription)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<JobDescription>()
                .HasMany(j => j.Employees)
                .WithOne(e => e.JobDescription)
                .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<EmployeeStatus>()
                .HasMany(s => s.Employees)
                .WithOne(e => e.EmployeeStatus)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<EmployeeSupervisor>()
                .HasKey(es => new  { es.SupervisorId, es.EmployeeId });

            modelBuilder.Entity<LoginLog>()
                .HasOne(l => l.Employee)
                .WithMany(e => e.LoginLogs)
                .HasForeignKey(l => l.EmployeeId);
        }
    }
}
