using Assignment1.Interfaces;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class SkillSetController : ControllerBase
    {
        private readonly ISkillSetRepository _dbSkillSet;
        //private readonly IMapper _mapper;
        public SkillSetController(ISkillSetRepository dbSkillSet)
        {
            _dbSkillSet = dbSkillSet;
        }


        [HttpGet(Name = "Get all SkillSets")]
        public async Task<ActionResult> GetAllSkillSets()
        {
            try
            {
                IEnumerable<SkillSet> skilList = await _dbSkillSet.GetAllSkillSet();
                return Ok(skilList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}", Name = "GetSkillSet")]
        public async Task<ActionResult> GetSkillSet(int id)
        {
            try
            {
                var emp = await _dbSkillSet.GetAsync(u => u.SkillSetId == id);
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

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateSkillSet([FromBody] SkillSet skillSet)
        {
            try
            {
                await _dbSkillSet.CreateSkillSet(skillSet);
                return Ok(skillSet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }



        }



        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name = "UpdateSkillSet")]

        public async Task<ActionResult> UpdateSkillSet(int id, [FromBody] SkillSet skillSet)
        {
            try
            {
                if (skillSet == null || id != skillSet.SkillSetId)
                    return BadRequest();


                await _dbSkillSet.UpdateSkillSet(skillSet);

                return Ok(skillSet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
