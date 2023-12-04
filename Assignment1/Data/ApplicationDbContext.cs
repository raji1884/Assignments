using System.Collections.Generic;
using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<SkillSetMap> SkillSetMap { get; set; }
    }
}
