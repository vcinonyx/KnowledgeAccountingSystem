using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IKnowledgeAreaRepository : IRepository<KnowledgeArea>
    {   
        Task<IEnumerable<Skill>> GetSkillsByKnowledgeAreaIdAsync(int AreaId);
    }
}
