using EmployeeAPIProject.Models;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPIProject.Controllers
{
    [ApiController]
    [Route("api/employees/supervisor")]

    // [Authorize]
    public class EmployeeSupervisorController : Controller
    {
        private readonly IEmployeeSupervisorService _employeeSupervisorService;

       public EmployeeSupervisorController(IEmployeeSupervisorService employeeSupervisorService)
        {
            _employeeSupervisorService = employeeSupervisorService;
        }
        [HttpGet("GetSupervisors")]
        public IActionResult GetSupervisors()
        {

            return Ok(_employeeSupervisorService.GetSupervisors());
        }
        [HttpPost("AddSupervisor")]
        public IActionResult AddSupervisor(EmployeeSupervisor supervisor)
        {

            if (ModelState.IsValid)
            {
                _employeeSupervisorService.AddSupervisor(supervisor);

                return Ok(supervisor);
            }
            return NotFound();
        }

    }
}
