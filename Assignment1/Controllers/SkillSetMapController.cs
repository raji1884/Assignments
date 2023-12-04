using Assignment1.Interfaces;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class SkillSetMapController : ControllerBase
    {
        private readonly ISkillSetMapRepository _dbSkillSetMap;
        //private readonly IMapper _mapper;
        public SkillSetMapController(ISkillSetMapRepository dbSkillSetMap)
        {
            _dbSkillSetMap = dbSkillSetMap;
        }

        [HttpPost ]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateSkillSetMap([FromBody] SkillSetMap skillsetmap)
        {
            try
            {
                await _dbSkillSetMap.CreateSkillSetMap(skillsetmap);
                return Ok(skillsetmap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet(Name = "Getall")]//
        public async Task<ActionResult> GetAllSkillSetMaps()
        {
            try
            {
                IEnumerable<SkillSetMap> ssmList = await _dbSkillSetMap.GetAllSkillSetMap();

                return Ok(ssmList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}", Name = "GetSkillSetMap")]
        public async Task<ActionResult> GetSkillSetMap(string id)
        {
            try
            {

                var emp = await _dbSkillSetMap.GetAsync(u => u.SkillSetMapId == id);
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

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name = "UpdateSkillSetMap")]

        public async Task<ActionResult> UpdateSkillSetMap(string id, [FromBody] SkillSetMap skillsetmap)
        {
            try
            {
                if (skillsetmap == null || id != skillsetmap.SkillSetMapId)
                    return BadRequest();


                await _dbSkillSetMap.UpdateSkillSetMap(skillsetmap);

                return Ok(skillsetmap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
