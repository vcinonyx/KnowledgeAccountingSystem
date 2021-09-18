using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserEvaluetedSkillRepository : IRepository<UserEvaluetedSkill>
    {
        public Task<IEnumerable<UserEvaluetedSkill>> GetSkillsByUserIdAsync(string userId);
    }
}
