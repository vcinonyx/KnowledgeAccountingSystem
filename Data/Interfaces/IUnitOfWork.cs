using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IKnowledgeAreaRepository KnowledgeAreaRepository { get; }
        ISkillRepository SkillRepository { get; }
        IUserEvaluetedSkillRepository UserEvaluetedSkillRepository { get; }
        Task<int> SaveAsync();
    }
}
