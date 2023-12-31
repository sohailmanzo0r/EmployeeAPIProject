using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EmployeeAPIProject.Repositories
{
    public interface IEmployee :IDisposable
    {
     
          IEnumerable<Employee> Get();
        
        void Add(Employee addedemployee);
          Employee Get([FromRoute] Guid id);
        void Update([FromRoute] Guid id, Employee EmployeeUpdateRequest);
          void delete(Guid id);

        void save();





    }
}
