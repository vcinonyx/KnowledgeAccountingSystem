using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserEvaluetedSkill : BaseEntity
    {
        public string UserId { get; set; }
        public int UserSkillsCardId { get; set; }
        public UserSkillsCard UserSkillsCard { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        [Range(1, 5)]
        public int Grade { get; set; }
    }
}
