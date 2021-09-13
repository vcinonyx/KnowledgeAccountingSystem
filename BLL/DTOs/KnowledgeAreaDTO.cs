using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class KnowledgeAreaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> SkillIds { get; set; }
    }
}
