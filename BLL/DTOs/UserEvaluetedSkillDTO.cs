using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserEvaluetedSkillDTO
    {
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string KnowledgeAreaName { get; set; }

        [Required]
        public int Grade { get; set; }
    }
}
