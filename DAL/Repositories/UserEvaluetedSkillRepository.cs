using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class UserEvaluetedSkillRepository : IUserEvaluetedSkillRepository
    {
        private readonly AccountingSystemDbContext _context;

        public UserEvaluetedSkillRepository(AccountingSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserEvaluetedSkill entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task DeleteAsync(UserEvaluetedSkill entity)
        {
            var evaluetedSkill = await _context.UserEvaluetedSkills.FindAsync(entity.Id);

            if (evaluetedSkill != null)
            {
                _context.UserEvaluetedSkills.Remove(evaluetedSkill);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var evaluetedSkill = await _context.UserEvaluetedSkills.FindAsync(id);

            if (evaluetedSkill != null)
            {
                _context.UserEvaluetedSkills.Remove(evaluetedSkill);
            }
        }

        public async Task<IEnumerable<UserEvaluetedSkill>> GetAllAsync()
        {
            return await _context.UserEvaluetedSkills.ToListAsync();
        }

        public async Task<IEnumerable<UserEvaluetedSkill>> GetAllWithDetailsAsync()
        {
            return await _context.UserEvaluetedSkills
                .Include(x => x.Skill)
                .ThenInclude(x => x.KnowledgeArea)
                .ToListAsync();
        }

        public async Task<UserEvaluetedSkill> GetByIdAsync(int id)
        {
            return await _context.UserEvaluetedSkills
                .Include(x => x.Skill)
                .ThenInclude(x => x.KnowledgeArea)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserEvaluetedSkill>> GetSkillsByUserIdAsync(string userId)
        {
            return await _context.UserEvaluetedSkills
                .Include(x => x.Skill)
                .ThenInclude(x => x.KnowledgeArea)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public void Update(UserEvaluetedSkill entity)
        {
            _context.UserEvaluetedSkills.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
