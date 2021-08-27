using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AccountingSystemDbContext : DbContext
    {
        public AccountingSystemDbContext (DbContextOptions<AccountingSystemDbContext> options) : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<KnowledgeArea> KnowledgeAreas { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
