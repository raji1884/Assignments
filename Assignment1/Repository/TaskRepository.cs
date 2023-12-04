using Assignment1.Data;
using Assignment1.Interfaces;
using Assignment1.Models;
using Dapper;
using System.Numerics;

namespace Assignment1.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public readonly DapperContext _dbcontext;
        public TaskRepository(DapperContext databaseContext)
        {
            _dbcontext = databaseContext;
        }

        public async Task<SkillSetMap> UpdateSkillSetByEmpId(string Empid, int SSid)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmpId", Empid);
                parameters.Add("@SsId", SSid);
                var procedure = "Update_SkillSet_By_Id";

                var results = await connection.QueryFirstAsync<SkillSetMap>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }

        }

        public async Task<string> GetHighestPaidEmp_SkillSet(string Skillset, string Empid)
        { // need to do role check
            using (var connection = _dbcontext.CreateConnection())
            {

                var parameter = new DynamicParameters(new { empId = Empid });

                var designation = await connection.QueryFirstAsync<string>("SELECT designation FROM Employee WHERE EmpId=@empId", parameter);
                if (designation.ToLower() == "manager")
                {

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@SSName", Skillset);
                    parameters.Add("@EmpId", Empid);
                    var procedure = "Select_HighestPaid_By_SkillSet";

                    var results = await connection.QueryFirstAsync<string>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    if (results == "")
                        return "No employee is there under this Skill set.";
                    else
                        return "Highest paid employee is : " + results;
            }
                else
                return "Not an Authorised user";
        }

        }

        public async Task<string> GetManagerName_EmpId(string Empid)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmpId", Empid);
                var procedure = "Select_Manager_By_EmpId";

                var results = await connection.QueryFirstAsync<string>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (results == "")
                    return "The person himself is Manager";
                else
                    return "The Manager is : " + results;
            }
        }

        public async Task<string> GetHighestPaidSkillSet()
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@EmpId", Empid);
                var procedure = "Select_HighestPaidSkillSet";

                var results = await connection.QueryFirstAsync<string>(procedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
                
                return "Highest paid Skill set is : " + results;
            }

        }
    }
}
