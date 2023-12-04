using Assignment1.Models;
using System.Numerics;

namespace Assignment1.Interfaces
{
    public interface ITaskRepository 
    {
        public Task<SkillSetMap> UpdateSkillSetByEmpId(string Empid, int SsId);

        public Task<string> GetHighestPaidEmp_SkillSet(string Skillset, string Empid);

        public Task<string> GetManagerName_EmpId(string Empid);

        public Task<string> GetHighestPaidSkillSet();
    }
}
