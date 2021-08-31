using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IKnowledgeAreaRepository KnowledgeAreaRepository { get; }
        ISkillRepository SkillRepository { get; }
        IUserEvaluetedSkillRepository UserEvaluetedSkillRepository { get; }
        IUserSkillsCardRepository UserSkillsCardRepository { get; }
        Task<int> SaveAsync();
    }
}
