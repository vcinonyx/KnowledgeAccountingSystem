using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserSkillsCardRepository : IRepository<UserSkillsCard>
    {
        Task<IEnumerable<UserEvaluetedSkill>> GetUserSkillsByIdAsync(int userId);
    }
}
