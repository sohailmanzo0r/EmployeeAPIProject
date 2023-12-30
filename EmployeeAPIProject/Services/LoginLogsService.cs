using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeAPIProject.Services
{
    public class LoginLogsService : ILoginLogsService
    {
        private readonly ILoginLogs _loginLogs;
        private readonly IConfiguration _configuration;

        public LoginLogsService(ILoginLogs loginLogs, IConfiguration configuration)
        {
            _loginLogs = loginLogs;
            _configuration = configuration;
        }
        public Employee LoginUser(Login user)
        {
            return _loginLogs.LoginUser(user);
        }
        public string GenerateJwtToken(Employee user)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, user.Email),
           
             
            // Add other claims as needed
           };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
