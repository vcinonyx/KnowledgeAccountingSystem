using System;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountingSystemDbContext _context;        

        public IKnowledgeAreaRepository KnowledgeAreaRepository => new KnowledgeAreaRepository(_context);
        public ISkillRepository SkillRepository => new SkillRepository(_context);
        public IUserEvaluetedSkillRepository UserEvaluetedSkillRepository => new UserEvaluetedSkillRepository(_context);

        public UnitOfWork(AccountingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
