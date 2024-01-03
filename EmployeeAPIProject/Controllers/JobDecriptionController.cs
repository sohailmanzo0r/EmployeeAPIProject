using EmployeeAPIProject.Models;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeAPIProject.Controllers;

    [ApiController]
    [Route("api/employees/jobDescription")]

    // [Authorize]
    public class JobDecriptionController : Controller
    {
        private readonly IJobDescriptionService _jobDescriptionService;

      public JobDecriptionController(IJobDescriptionService jobDescriptionService)
        {
           _jobDescriptionService = jobDescriptionService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_jobDescriptionService.Get());
        }
        [HttpPost]
        public IActionResult Add(JobDescription addjob)
        {

            if (ModelState.IsValid)
            {
                _jobDescriptionService.Add(addjob);

                return Ok(addjob);
            }
            return NotFound();
        }
    }

