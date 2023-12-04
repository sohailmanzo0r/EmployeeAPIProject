using EmployeeAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Data
{
    public class EmployeeDbContext:DbContext
    {
       
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) { }
      public  DbSet<Employee> employees {  get; set; }
    }
}
