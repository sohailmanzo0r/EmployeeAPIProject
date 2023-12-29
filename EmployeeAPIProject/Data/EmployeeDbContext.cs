using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Data
{
    public class EmployeeDbContext:DbContext
    {
       
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) { }
      public  DbSet<Employee> Employees {  get; set; }
        public DbSet<JobDescription> JobDescription { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatus { get; set; }
        public DbSet<EmployeeSupervisor> EmployeeSupervisor { get; set; }
        public DbSet<LoginLog> LoginLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
             .HasOne(e => e.JobDescription)
             .WithMany(j => j.Employees)
             .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmployeeStatus)
                .WithMany(es => es.Employees)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Supervisors)
                .WithOne(es => es.Employee)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LoginLogs)
                .WithOne(l => l.Employee)
                .HasForeignKey(l => l.EmployeeId);

            modelBuilder.Entity<EmployeeSupervisor>()
           .HasKey(es => new { es.EmployeeId, es.SupervisorId });

            modelBuilder.Entity<EmployeeSupervisor>()
                .HasOne<Employee>(es => es.Employee)
                .WithMany(e => e.Supervisors)
                .HasForeignKey(es => es.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeStatus>()
                .HasMany(es => es.Employees)
                .WithOne(e => e.EmployeeStatus)
                .HasForeignKey(e => e.StatusId);

            modelBuilder.Entity<JobDescription>()
                .HasMany(j => j.Employees)
                .WithOne(e => e.JobDescription)
                .HasForeignKey(e => e.JobId);

            // Include your configurations for LoginLog, if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
