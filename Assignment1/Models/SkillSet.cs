using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class SkillSet
    {
        [Required]
        public int SkillSetId { get; set; }
        [Required]
        public string SkillSetName { get; set; }
    }
}
