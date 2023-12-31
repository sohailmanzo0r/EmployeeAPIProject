using EmployeeAPIProject.Data;
using EmployeeAPIProject.Migrations;
using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Controllers
{
  [Authorize]
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUtilityService _utilityService;

        public EmployeeController(IEmployeeService employeeService, IUtilityService utilityService)
        {
             
             _employeeService = employeeService;
           _utilityService = utilityService;
        }
       
        [HttpGet]
        public   IActionResult Get()
        {

            return Ok(_employeeService.Get());
        }
        [HttpPost]
        public   IActionResult Add( Employee addedemployee)
        {

            if (ModelState.IsValid)
            {
                _employeeService.Add(addedemployee);
              
                return Ok(addedemployee);
            }
            return NotFound();

        }
       
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
             return Ok(_employeeService.Get(id));


        }
        [HttpPut]
        [Route("{id:Guid}")]
        public  IActionResult Update([FromRoute] Guid id, Employee EmployeeUpdateRequest)
        {
            if (ModelState.IsValid)
            {

                _employeeService.Update(id, EmployeeUpdateRequest);
                 
                return Ok(EmployeeUpdateRequest);
            }
            return NotFound();


        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public  IActionResult delete([FromRoute] Guid id)
        {   
            _employeeService.delete(id);
            return Ok();
        }

        private string calculateAge(DateTime dob)

        {
           return _utilityService.calculateAge(dob);
        }
         
    }

}
