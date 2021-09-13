using BLL.DTOs;
using DAL.Entities;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic; 


namespace BLL.Interfaces
{
    public interface IKnowledgeAreaService : ICrud<KnowledgeAreaDTO>
    {
        Task AddSkillToKnowledgeAreaAsync(int knowledgeAreaId, SkillDTO skillModel);
        Task<IEnumerable<SkillDTO>> GetSkillsByKnowledgeAreaId(int knowledgeAreaId);
    }

}
