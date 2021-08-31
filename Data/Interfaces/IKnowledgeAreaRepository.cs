using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IKnowledgeAreaRepository : IRepository<KnowledgeArea>
    {   
        Task<IEnumerable<Skill>> GetSkillsByKnowledgeAreaIdAsync(int AreaId);
    }
}
