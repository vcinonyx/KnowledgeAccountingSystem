using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class SkillDTO
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int KnowledgeAreaId { get; set; }
    }
}
