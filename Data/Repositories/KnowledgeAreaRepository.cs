using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class KnowledgeAreaRepository : IKnowledgeAreaRepository
    {
        private readonly AccountingSystemDbContext _context;

        public KnowledgeAreaRepository(AccountingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetSkillsByKnowledgeAreaIdAsync (int AreaId)
        {
            var knowledgeArea = await _context.KnowledgeAreas.Include(x => x.Skills).FirstOrDefaultAsync(x => x.Id == AreaId);
            return knowledgeArea.Skills;
        }

        public async Task<IEnumerable<KnowledgeArea>> GetAllWithDetailsAsync()
        {
            return await _context.KnowledgeAreas.Include(x => x.Skills).ToListAsync();
        }

        public async Task<IEnumerable<KnowledgeArea>> GetAllAsync()
        {
            return await _context.KnowledgeAreas.ToListAsync();
        }

        public async Task<KnowledgeArea> GetByIdAsync(int id)
        {
            return await _context.KnowledgeAreas.Include(x => x.Skills).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(KnowledgeArea entity)
        {
            await _context.KnowledgeAreas.AddAsync(entity);
        }

        public void Update(KnowledgeArea entity)
        {
            _context.KnowledgeAreas.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(KnowledgeArea entity)
        {
            var knowledgeArea = await _context.KnowledgeAreas.FindAsync(entity.Id);

            if (knowledgeArea != null)
            {
                _context.KnowledgeAreas.Remove(knowledgeArea);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var knowledgeArea = await _context.KnowledgeAreas.FindAsync(id);

            if (knowledgeArea != null)
            {
                _context.KnowledgeAreas.Remove(knowledgeArea);
            }
        }
    }
}
