using System.Collections.Generic;

namespace Data.Entities
{
    public class KnowledgeArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
