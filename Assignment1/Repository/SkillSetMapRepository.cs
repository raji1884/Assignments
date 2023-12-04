using Assignment1.Data;
using Assignment1.Interfaces;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Repository
{
    public class SkillSetMapRepository : Repository<SkillSetMap>, ISkillSetMapRepository
    {
        private readonly ApplicationDbContext _db;

        public SkillSetMapRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<SkillSetMap> CreateSkillSetMap(SkillSetMap skillsetmap)
        {
            await dbSet.AddAsync(skillsetmap);
            await SaveAsync();
            return skillsetmap;
        }

        public async Task<List<SkillSetMap>> GetAllSkillSetMap()
        {
            IQueryable<SkillSetMap> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<SkillSetMap> GetSkillSetMapById(string id)
        {
            IQueryable<SkillSetMap> query = dbSet;
            return await query.FirstOrDefaultAsync();
        }

        public async Task<SkillSetMap> UpdateSkillSetMap(SkillSetMap skillsetmap)
        {
            _db.SkillSetMap.Update(skillsetmap);
            await _db.SaveChangesAsync();
            return skillsetmap;
        }

    }
}
