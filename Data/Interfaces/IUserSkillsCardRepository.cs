using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserSkillsCardRepository : IRepository<UserSkillsCard>
    {
        Task<IReadOnlyList<UserEvaluetedSkill>> GetUserSkillsByIdAsync(int userId);
    }

}
