using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class KnowledgeAreaDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<SkillDTO>  Skills { get; set; }
    }
}
