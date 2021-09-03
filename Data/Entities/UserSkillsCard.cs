using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UserSkillsCard : BaseEntity
    {
        public int UserId { get; set; }
        public ICollection<UserEvaluetedSkill> UserSkills { get; set; } 
    }
}
