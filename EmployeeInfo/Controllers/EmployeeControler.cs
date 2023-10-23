using EmployeeInfo.Model.dto;
using EmployeeInfo.repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;

namespace EmployeeInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeControler : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeControler(IEmployeeRepo employeeRepo) {
            this.employeeRepo = employeeRepo;

        }

        [HttpPost("Create")]
        [Authorize]
        //[AllowAnonymous]
        public async Task<IActionResult> Create(empolyee employee)
        {
            var exist = await employeeRepo.GetAsync(employee.EmpCode);
            if (exist is not null)
            {
                return BadRequest("employee already exists");
            }
            var result = await this.employeeRepo.Create(employee);
            if (result != null)
            {
                return Created($"Get/{result.EmpCode}", result);
            }
            else
            {
                return BadRequest("Data Insertion failed");
            }

        }



        [HttpGet("Get/{EmpCode}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
        public async Task<IActionResult> Get(string EmpCode)
        {
            var result = await this.employeeRepo.GetAsync(EmpCode);
            if(result != null) {
            return Ok(result);  
            }
            else
            {
                return NotFound("No Record Found");
            }

        }

        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(string EmpCode)
        {
            var result = await this.employeeRepo.Delete(EmpCode);
            return Ok(result);

        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update(empolyee empolyee)
        {
            var result = await this.employeeRepo.UpdateRole(empolyee.Role, empolyee.EmpCode);
            if (result != null)
            {
                return Ok("Data Updated successfully");
            }
            else
            {
                return NotFound("Employee Not found");
            }

        }
    }
}
