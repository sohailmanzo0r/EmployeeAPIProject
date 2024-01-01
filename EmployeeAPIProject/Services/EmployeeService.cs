﻿using EmployeeAPIProject.Data;
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
        private readonly IJobDescription _jobDescription;
        private readonly IEmployeeStatus _employeeStatus;
        private readonly IUtilityService _utilityService;

        public EmployeeService(IEmployee employeeRepository, IConfiguration configuration,IJobDescription jobDescription,IEmployeeStatus employeeStatus, IUtilityService utilityService)
        {
            _employeeRepository = employeeRepository;
            _jobDescription = jobDescription;
            _employeeStatus = employeeStatus;
            _utilityService = utilityService;
        }
        public void Add(Employee addedemployee)

        {
             var jobdescription = _jobDescription.Get(addedemployee.JobId);
            var status= _employeeStatus.Get(addedemployee.StatusId);
            addedemployee.EmployeeStatus = status;
            addedemployee.JobDescription = jobdescription;
            addedemployee.Id = new Guid();
            _employeeRepository.Add(addedemployee);
        }

        public void delete(Guid id)
        {
            _employeeRepository.Delete(id);
        }

        public IEnumerable<EmployeeDTO> Get()
        {
            var employees = _employeeRepository.Get();
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
                employeeDTO.EmployeeStatus = emp.EmployeeStatus;
                employeeDTO.JobDescription = emp.JobDescription;
                employeeDTO.JobId = emp.JobId;
                employeeDTO.StatusId = emp.StatusId;

                employeeDTO.LaterStatus = emp.LaterStatus;
                employeeDTO.StatusChangeDate = emp.StatusChangeDate;
                employeeDTO.StatusChangeReason = emp.StatusChangeReason;
                employeeDTO.StatusChangeChoice = emp.StatusChangeChoice;
                employeeDTO.Age = _utilityService.calculateAge(emp.DOB);
                employees1.Add(employeeDTO);

            }
            return employees1;
        }

        public EmployeeDTO Get(Guid id)
        {
            var emp = _employeeRepository.Get(id);
            EmployeeDTO emp1 = new EmployeeDTO();
            emp1.Id = emp.Id;
            emp1.Name = emp.Name;
            emp1.Email = emp.Email;
            emp1.Phone = emp.Phone;
            emp1.Department = emp.Department;
            emp1.Password = emp.Password;
            emp1.Salary = emp.Salary;
            emp1.DOB = emp.DOB;
            emp1.EmployeeStatus = emp.EmployeeStatus;
            emp1.LaterStatus = emp.LaterStatus;
            emp1.StatusChangeDate = emp.StatusChangeDate;
            emp1.StatusChangeReason = emp.StatusChangeReason;
            emp1.StatusChangeChoice = emp.StatusChangeChoice;
            emp1.Age = _utilityService.calculateAge(emp.DOB);
            emp1.JobDescription = emp.JobDescription;
            emp1.JobId = emp.JobId;
            emp1.StatusId = emp.StatusId;

            return emp1;
        }

        public void Update([FromRoute] Guid id, Employee EmployeeUpdateRequest)
        {

            _employeeRepository.Update(id, EmployeeUpdateRequest);
        }
    }

}

