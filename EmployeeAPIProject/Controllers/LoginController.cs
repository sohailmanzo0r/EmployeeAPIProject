using EmployeeAPIProject.Models;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeAPIProject.Controllers;

[ApiController]
[Route("api/employees/login")]
public class LoginController : Controller
{
    private readonly ILoginLogsService _loginLogsService;

   public LoginController(ILoginLogsService loginLogsService)
    {
        _loginLogsService = loginLogsService;
    }
    [AllowAnonymous]
    [HttpPost]
    public IActionResult LoginUser(Login user)
    {
        var loggedInUser = _loginLogsService.LoginUser(user);
        if (loggedInUser != null)
        {
            var token = _loginLogsService.GenerateJwtToken(loggedInUser);
            return Ok(new { Token = token });
        }
        return Unauthorized();

    }
}
