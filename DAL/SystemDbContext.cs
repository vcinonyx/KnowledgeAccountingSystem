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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Seed();
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<KnowledgeArea> KnowledgeAreas { get; set; }
        public DbSet<UserEvaluetedSkill> UserEvaluetedSkills { get; set; }
    }
}
