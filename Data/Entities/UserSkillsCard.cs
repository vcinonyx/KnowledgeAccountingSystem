using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class UserSkillsCard : BaseEntity
    {
        public int UserId { get; set; }
        public ICollection<UserEvaluetedSkill> UserSkills { get; set; } 
    }
}
