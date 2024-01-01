using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployee :IDisposable
    {
     
          IEnumerable<Employee> Get();

        public bool Add(Employee addedEmployee);
          Employee Get([FromRoute] Guid id);
        public bool Update(Guid id, Employee employeeUpdateRequest);
        public bool Delete(Guid id);

        public bool save(); // Purpose of save method in interface is because it is using in status change method in status service





    }
}
