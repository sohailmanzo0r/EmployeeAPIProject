using EmployeeAPIProject.Data;
using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeAPIProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected readonly IEmployee _employeeRepository;
        private readonly IConfiguration _configuration;

        public EmployeeService(IEmployee employeeRepository, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _configuration = configuration;
        }
        public void AddEmployee(Employee addedemployee)

        {
            addedemployee.Id = new Guid();
            _employeeRepository.AddEmployee(addedemployee);
        }

        public string calculateAge(string dob)
        {
            DateTime dateOfBirth;

            bool check = DateTime.TryParse(dob, out dateOfBirth);
            if (check == false)
            {
                return "invalid date of birth";
            }
            DateTime currentDate = DateTime.Now;

            TimeSpan difference = currentDate.Subtract(dateOfBirth);

            // This is to convert the timespan to datetime object
            DateTime age = DateTime.MinValue + difference;

            // Min value is 01/01/0001
            // Actual age is say 24 yrs, 9 months and 3 days represented as timespan
            // Min Valye + actual age = 25 yrs , 10 months and 4 days.
            // subtract our addition or 1 on all components to get the actual date.

            int ageInYears = age.Year - 1;
            int ageInMonths = age.Month - 1;
            int ageInDays = age.Day - 1;

            return " Year " + ageInYears + ",Months " + ageInMonths + " ,Days " + ageInDays;
        }

        public void deleteEmployee(Guid id)
        {
            _employeeRepository.deleteEmployee(id);
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            List<EmployeeDTO> employees1 = new List<EmployeeDTO>();
            foreach (Employee emp in employees)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.Id = emp.Id;
                employeeDTO.Name = emp.Name;
                employeeDTO.Email = emp.Email;
                employeeDTO.Phone = emp.Phone;
                employeeDTO.Department = emp.Department;
                employeeDTO.Password = emp.Password;
                employeeDTO.Salary = emp.Salary;
                employeeDTO.DOB = emp.DOB;
                employeeDTO.status = emp.status;
                employeeDTO.StatusChangeReason = emp.StatusChangeReason;
                employeeDTO.StatusChangeDate = emp.StatusChangeDate;
                employeeDTO.StatusChangeChoice = emp.StatusChangeChoice;
                employeeDTO.laterstatus = emp.laterstatus;
                employeeDTO.Age = calculateAge(emp.DOB);
                employees1.Add(employeeDTO);

            }
            return employees1;
        }

        public EmployeeDTO GetEmployee(Guid id)
        {
            var emp = _employeeRepository.GetEmployee(id);
            EmployeeDTO emp1 = new EmployeeDTO();
            emp1.Id = emp.Id;
            emp1.Name = emp.Name;
            emp1.Email = emp.Email;
            emp1.Phone = emp.Phone;
            emp1.Department = emp.Department;
            emp1.Password = emp.Password;
            emp1.Salary = emp.Salary;
            emp1.DOB = emp.DOB;
            emp1.status = emp.status;
            emp1.StatusChangeReason = emp.StatusChangeReason;
            emp1.StatusChangeDate = emp.StatusChangeDate;
            emp1.StatusChangeChoice = emp.StatusChangeChoice;
            emp1.laterstatus = emp.laterstatus;
            emp1.Age = calculateAge(emp.DOB);

            if (emp1 == null)
            {
                return null;
            }

            return emp1;
        }

        public Employee LoginUser(Login user)
        {

            var employee = _employeeRepository.LoginUser(user);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public void UpdateEmployee([FromRoute] Guid id, Employee EmployeeUpdateRequest)
        {

            _employeeRepository.UpdateEmployee(id, EmployeeUpdateRequest);
        }

        public void ChangeStatus(Guid id, Employee statusChangeRequest)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee != null)
            {

                employee.status = statusChangeRequest.status;
                employee.StatusChangeChoice = statusChangeRequest.StatusChangeChoice;
                employee.StatusChangeDate = statusChangeRequest.StatusChangeChoice.ToLower() == "later"
                    ? statusChangeRequest.StatusChangeDate
                    : DateTime.Now;

                // Store the reason and additional property
                employee.StatusChangeReason = statusChangeRequest.StatusChangeReason;
                employee.laterstatus = statusChangeRequest.laterstatus;
                _employeeRepository.save();
            }
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

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }
               
    }

}

