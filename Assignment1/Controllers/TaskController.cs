using Assignment1.Interfaces;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : ControllerBase
    {
        public readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }



        [Route("UpdateSkillSetByEmpId")]
        [HttpPut]
        public async Task<IActionResult> UpdateSkillSetByEmpId(string empId, int ssId)
        {
            try
            {
                var model = await _taskRepository.UpdateSkillSetByEmpId(empId, ssId);
                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetHighestPaidEmployeeBySkillSet")]
        [HttpGet]
        public async Task<IActionResult> GetHighestPaidEmp_SkillSet(string skillset, string empId)
        {
            try
            {
                var model = await _taskRepository.GetHighestPaidEmp_SkillSet(skillset, empId);
                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetManagerNameByEmpId")]
        public async Task<IActionResult> GetManagerName_EmpId(string empid)
        {
            try
            {
                var model = await _taskRepository.GetManagerName_EmpId(empid);
                return Ok(model);
                //return Ok("OK");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            // return Ok("OK");
        }

        [Route("GetHighestPaidSkillSet")]
        [HttpGet]
        public async Task<IActionResult> GetHighestPaidSkillSet()
        {
            try
            {
                var model = await _taskRepository.GetHighestPaidSkillSet();
                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
