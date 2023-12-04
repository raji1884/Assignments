using Assignment1.Data;
using Assignment1.Interfaces;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Repository
{
    public class SkillSetRepository : Repository<SkillSet>, ISkillSetRepository
    {
        private readonly ApplicationDbContext _db;

        public SkillSetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<SkillSet> CreateSkillSet(SkillSet skillSet)
        {
            await dbSet.AddAsync(skillSet);
            await SaveAsync();
            return skillSet;
        }

        public async Task<List<SkillSet>> GetAllSkillSet()
        {
            IQueryable<SkillSet> query = dbSet;
            return await query.ToListAsync();
        }
        
        public async Task<SkillSet> GetSkillSetById(int? Id)
        {
            IQueryable<SkillSet> query = dbSet;
            return await query.FirstOrDefaultAsync();
        }

       
        public async Task<SkillSet> UpdateSkillSet(SkillSet skillSet)
        {
            
            _db.SkillSets.Update(skillSet);
            await _db.SaveChangesAsync();
            return skillSet;
        }

    }
}
