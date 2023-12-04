using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Employee
    {
        [Key]
        public string EmpId { get; set; }

        public string EmpName { get; set; }

        public string Designation { get; set; }
        public string ManagerId { get; set; }

        public int Salary { get; set; }
    }
}
