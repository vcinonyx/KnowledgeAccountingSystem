using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AccountingSystemDbContext _context;

        public SkillRepository(AccountingSystemDbContext context)
        {
            _context = context;
        }

        public  async Task AddAsync(Skill entity)
        {
            await _context.Skills.AddAsync(entity);
        }

        public async Task DeleteAsync(Skill entity)
        {
            var skill = await _context.Skills.FindAsync(entity.Id);

            if (skill != null)
            {
                _context.Skills.Remove(skill);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill != null)
            {
                _context.Skills.Remove(skill);
            }
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetAllWithDetailsAsync()
        {
            return await _context.Skills.Include(x => x.KnowledgeArea).ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            return await _context.Skills.Include(x => x.KnowledgeArea)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Skill entity)
        {
            _context.Skills.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
