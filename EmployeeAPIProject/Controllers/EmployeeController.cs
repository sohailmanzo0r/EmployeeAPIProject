﻿
using EmployeeAPIProject.Models;
using EmployeeAPIProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 
namespace EmployeeAPIProject.Controllers;

     [Authorize]
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
        public   IActionResult Get()
        {

            return Ok(_employeeService.Get());
        }
        [HttpPost]
        public   IActionResult Add( Employee addedemployee)
        {

            if (ModelState.IsValid)  // This is a form of initial, surface-level validation, to check if the model
                                     //  data is valid according to the validation attributes applied to the model properties
        {
            _employeeService.Add(addedemployee);
              
                return Ok(addedemployee);
            }
            return BadRequest();

        }
       
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
             return Ok(_employeeService.Get(id));


        }
        [HttpPut]
        [Route("{id:Guid}")]
        public  IActionResult Update([FromRoute] Guid id, Employee EmployeeUpdateRequest)
        {
            if (ModelState.IsValid)
            {

                _employeeService.Update(id, EmployeeUpdateRequest);
                 
                return Ok(EmployeeUpdateRequest);
            }
            return NotFound();


        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public  IActionResult delete([FromRoute] Guid id)
        {   
            _employeeService.delete(id);
            return Ok();
        }

         
    }


