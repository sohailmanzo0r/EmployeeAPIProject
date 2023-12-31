using EmployeeAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIProject.Services
{
    public interface IEmployeeService
    {
         IEnumerable<EmployeeDTO> Get();
        void Add(Employee addedemployee);
        EmployeeDTO Get([FromRoute] Guid id);
        void Update([FromRoute] Guid id, Employee EmployeeUpdateRequest);
        void delete(Guid id);
      
    }
}
