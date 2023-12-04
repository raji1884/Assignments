using Assignment1.Models;

namespace Assignment1.Interfaces
{
    public interface ISkillSetMapRepository : IRepository<SkillSetMap>
    {
        public Task<List<SkillSetMap>> GetAllSkillSetMap();

        public Task<SkillSetMap> GetSkillSetMapById(string? Id);
        public Task<SkillSetMap> CreateSkillSetMap(SkillSetMap SkillSetMap);
        public Task<SkillSetMap> UpdateSkillSetMap(SkillSetMap SkillSetMap);
    }
}
