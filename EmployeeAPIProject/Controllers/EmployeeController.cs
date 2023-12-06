using EmployeeAPIProject.Data;
using EmployeeAPIProject.Migrations;
using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIProject.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
             
             _employeeService = employeeService;
        }
     
        [HttpGet]
        public   IActionResult GetAllEmployees()
        {

            return Ok(_employeeService.GetAllEmployees());
        }
        [HttpPost]
        public   IActionResult AddEmployee( Employee addedemployee)
        {

            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(addedemployee);
              
                return Ok(addedemployee);
            }
            return NotFound();

        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployee([FromRoute] Guid id)
        {
             return Ok(_employeeService.GetEmployee(id));


        }
        [HttpPut]
        [Route("{id:Guid}")]
        public  IActionResult UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest)
        {
            if (ModelState.IsValid)
            {

                _employeeService.UpdateEmployee(id, EmployeeUpdateRequest);
                 
                return Ok(EmployeeUpdateRequest);
            }
            return NotFound();


        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public  IActionResult deleteEmployee([FromRoute] Guid id)
        {   
            _employeeService.deleteEmployee(id);
            return Ok();
        }
        [HttpPost("LoginUser")]
        public IActionResult LoginUser(Login user)
        {
                
                return Ok(_employeeService.LoginUser(user));
        }
        [HttpPut]
        [Route("changeStatus/{id:Guid}")]
        public IActionResult ChangeStatus([FromRoute] Guid id, Employee statusChangeRequest)
        {
            _employeeService.ChangeStatus(id, statusChangeRequest);
            return Ok();
        }

        private string calculateAge(string dob)

        {
           return _employeeService.calculateAge(dob);
        }


    }
}
