using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AccountingSystemDbContext : DbContext
    {
        public AccountingSystemDbContext (DbContextOptions<AccountingSystemDbContext> options) : base(options)
        {
        }

        public AccountingSystemDbContext()
        {
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<KnowledgeArea> KnowledgeAreas { get; set; }
        public DbSet<UserEvaluetedSkill> UserEvaluetedSkills { get; set; }
        public DbSet<UserSkillsCard> UserSkillsCards { get; set; }
    }
}
