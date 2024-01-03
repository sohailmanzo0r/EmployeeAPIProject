using EmployeeAPIProject.Models;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeAPIProject.Controllers;

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
        [Route("{id:Guid}")]
        public IActionResult Change([FromRoute]Guid id, Employee statusChangeRequest)
        {
            _employeeStatusService.Change(id, statusChangeRequest);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeStatusService.Get());
        }
    }

