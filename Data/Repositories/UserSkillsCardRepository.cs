using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    class UserSkillsCardRepository : IUserSkillsCardRepository
    {
        private readonly AccountingSystemDbContext _context;

        public UserSkillsCardRepository(AccountingSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserSkillsCard entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task DeleteAsync(UserSkillsCard entity)
        {
            var userCard = await _context.UserSkillsCards.FindAsync(entity.Id);

            if (userCard != null)
            {
                _context.UserSkillsCards.Remove(userCard);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var userCard = await _context.UserSkillsCards.FindAsync(id);

            if (userCard != null)
            {
                _context.UserSkillsCards.Remove(userCard);
            }
        }

        public async Task<IEnumerable<UserSkillsCard>> GetAllAsync()
        {
            return await _context.UserSkillsCards.ToListAsync();
        }

        public async Task<IEnumerable<UserSkillsCard>> GetAllWithDetailsAsync()
        {
            return await _context.UserSkillsCards.Include(x => x.UserSkills).ToListAsync();
        }

        public async Task<UserSkillsCard> GetByIdAsync(int id)
        {
            return await _context.UserSkillsCards.Include(x => x.UserSkills)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserEvaluetedSkill>> GetUserSkillsByUserIdAsync(string userId)
        {
            var user = await _context.UserSkillsCards.Include(x => x.UserSkills)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (user != null)
            {
                return user.UserSkills;
            }

            return null;
        }

        public void Update(UserSkillsCard entity)
        {
            _context.UserSkillsCards.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
