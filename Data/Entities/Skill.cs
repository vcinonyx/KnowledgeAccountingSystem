namespace Data.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public int KnowledgeAreaId { get; set; }
        public KnowledgeArea KnowledgeArea { get; set; }
    }
}
