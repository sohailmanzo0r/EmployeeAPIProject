using EmployeeAPIProject.Models;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeAPIProject.Controllers;

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
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_employeeSupervisorService.Get());
        }
        [HttpPost]
        public IActionResult Add(EmployeeSupervisor supervisor)
        {

            if (ModelState.IsValid)
            {
                _employeeSupervisorService.Add(supervisor);

                return Ok(supervisor);
            }
            return NotFound();
        }

    }

