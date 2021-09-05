using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserSkillsCard : BaseEntity
    {
        public string UserId { get; set; }
        public ICollection<UserEvaluetedSkill> UserSkills { get; set; } 
    }
}
