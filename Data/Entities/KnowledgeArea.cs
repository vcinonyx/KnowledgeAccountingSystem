using System.Collections.Generic;

namespace Data.Entities
{
    public class KnowledgeArea : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
