using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class SkillSetMap
    {
        [Required]
        public string SkillSetMapId { get; set; }
        public int SkillSetId { get; set; }
        public string EmpId { get; set; }
    }
}
