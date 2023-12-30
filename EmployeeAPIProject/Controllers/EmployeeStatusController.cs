using EmployeeAPIProject.Models;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIProject.Controllers
{
    [ApiController]
    [Route("api/employees/status")]

    // [Authorize]
    public class EmployeeStatusController : Controller
    {
        private readonly IEmployeeStatusService _employeeStatusService;
        public EmployeeStatusController(IEmployeeStatusService employeeStatusService) {
            _employeeStatusService = employeeStatusService;
        }

        [HttpPut]
        [Route("changeStatus/{id:Guid}")]
        public IActionResult ChangeStatus([FromRoute] Guid id, Employee statusChangeRequest)
        {
            _employeeStatusService.ChangeStatus(id, statusChangeRequest);
            return Ok();
        }
        [HttpGet("GetEmployeeStatus")]
        public IActionResult GetEmployeeStatus()
        {
            return Ok(_employeeStatusService.GetEmployeeStatus());
        }
    }
}
