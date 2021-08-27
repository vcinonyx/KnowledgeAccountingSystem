using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public KnowledgeArea KnowledgeArea { get; set; }

        [Range(1, 5)] 
        public int Grade { get; set; }
    }
}
