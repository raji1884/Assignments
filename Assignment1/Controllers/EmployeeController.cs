using Assignment1.Interfaces;
using Assignment1.Models;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _dbEmployee;
        //private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository dbEmployee)
        {
            _dbEmployee = dbEmployee;
        }


        [HttpGet]
        [Route("Get all Employees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> empList = await _dbEmployee.GetAllEmployee();

                return Ok(empList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]//
        [Route("Get Employee")]
        public async Task<ActionResult> GetEmployee(string id)
        {
            try
            {
                var emp = await _dbEmployee.GetAsync(u => u.EmpId == id);
                if (emp == null)
                {
                    return NotFound();
                }
               
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost]
        [Route("Create Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (await _dbEmployee.GetAsync(u => u.EmpName.ToLower() == employee.EmpName.ToLower()) != null)
                {
                    ModelState.AddModelError("Custom error", "Employee already exists");
                    return BadRequest(ModelState);
                }

                await _dbEmployee.CreateEmployee(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]//("{id}")
        [Route("Update Employee")]

        public async Task<ActionResult> UpdateEmployee(string id, [FromBody] Employee employee)
        {
            try
            {
                if (employee == null || id != employee.EmpId)
                    return BadRequest();


                await _dbEmployee.UpdateEmployee(employee);
               
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch]//("{id}")
        [Route("Update Patch Employee")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialEmployee(string id, JsonPatchDocument<Employee> emppatch)
        {
            if (emppatch == null )
                return BadRequest();

            var employee = await _dbEmployee.GetAsync(u => u.EmpId == id, tracked: false);
           

            if (employee == null)
                return BadRequest();
            emppatch.ApplyTo(employee, ModelState);
            

            await _dbEmployee.UpdateEmployee(employee);

            return Ok(employee);

        }



    }
}
