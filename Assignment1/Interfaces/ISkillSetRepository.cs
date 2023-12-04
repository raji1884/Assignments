using Assignment1.Models;

namespace Assignment1.Interfaces
{
    public interface ISkillSetRepository : IRepository<SkillSet>
    {
        public Task<List<SkillSet>> GetAllSkillSet();

        public Task<SkillSet> GetSkillSetById(int? Id);
        public Task<SkillSet> CreateSkillSet(SkillSet skillSet);
        public  Task<SkillSet> UpdateSkillSet(SkillSet SkillSet);
    }
}
