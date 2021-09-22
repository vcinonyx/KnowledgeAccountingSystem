using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeArea>()
               .HasData(
                   new KnowledgeArea
                   {
                       Id = 1,
                       Name = "Programming Languages"
                   },
                   new KnowledgeArea
                   {
                       Id = 2,
                       Name = "Source Control"
                   },
                   new KnowledgeArea
                   {
                       Id = 3,
                       Name = "IDEs (Integrated Development Environment)"
                   },
                   new KnowledgeArea
                   {
                       Id = 4,
                       Name = "Databases"
                   },
                   new KnowledgeArea
                   {
                       Id = 5,
                       Name = "Operating Systems"
                   }
               );

            modelBuilder.Entity<Skill>()
                .HasData(
                    new Skill { Id = 1, KnowledgeAreaId = 1, Name = "C#" },
                    new Skill { Id = 2, KnowledgeAreaId = 1, Name = "C/C++" },
                    new Skill { Id = 3, KnowledgeAreaId = 1, Name = "Java" },
                    new Skill { Id = 4, KnowledgeAreaId = 1, Name = "Python" },
                    new Skill { Id = 5, KnowledgeAreaId = 1, Name = "JavaScript" },
                    new Skill { Id = 6, KnowledgeAreaId = 1, Name = "TypeScript"},
                    new Skill { Id = 7, KnowledgeAreaId = 1, Name = "PHP"},
                    new Skill { Id = 8, KnowledgeAreaId = 1, Name = "Go" },
                    new Skill { Id = 9, KnowledgeAreaId = 1, Name = "Kotlin"},
                    new Skill { Id = 10, KnowledgeAreaId = 1, Name = "Swift"},

                    new Skill { Id = 11, KnowledgeAreaId = 2, Name = "Git"},
                    new Skill { Id = 12, KnowledgeAreaId = 2, Name = "Mercurial" },
                    new Skill { Id = 13, KnowledgeAreaId = 2, Name = "Perforce Helix Core" },

                    new Skill { Id = 14, KnowledgeAreaId = 3, Name = "Visual Studio"},
                    new Skill { Id = 15, KnowledgeAreaId = 3, Name = "Eclipse" },
                    new Skill { Id = 16, KnowledgeAreaId = 3, Name = "Visual Studio Code" },
                    new Skill { Id = 17, KnowledgeAreaId = 3, Name = "Android Studio" },
                    new Skill { Id = 18, KnowledgeAreaId = 3, Name = "PyCharm" },
                    new Skill { Id = 19, KnowledgeAreaId = 3, Name = "Rider"},
                    new Skill { Id = 20, KnowledgeAreaId = 3, Name = "NetBeans" },
                    new Skill { Id = 21, KnowledgeAreaId = 3, Name = "Xcode" },

                    new Skill { Id = 22, KnowledgeAreaId = 4, Name = "SQL"},
                    new Skill { Id = 23, KnowledgeAreaId = 4, Name = "T-SQL" },
                    new Skill { Id = 24, KnowledgeAreaId = 4, Name = "MySQL" },
                    new Skill { Id = 25, KnowledgeAreaId = 4, Name = "Oracle" },
                    new Skill { Id = 26, KnowledgeAreaId = 4, Name = "PostgreSQL"},
                    new Skill { Id = 27, KnowledgeAreaId = 4, Name = "Microsoft SQL Server"},
                    new Skill { Id = 28, KnowledgeAreaId = 4, Name = "NoSQL" },
                    new Skill { Id = 29, KnowledgeAreaId = 4, Name = "MongoDB" },
                    new Skill { Id = 30, KnowledgeAreaId = 4, Name = "Redis" },

                    new Skill { Id = 31, KnowledgeAreaId = 5, Name = "Linux" },
                    new Skill { Id = 32, KnowledgeAreaId = 5, Name = "MacOS" },
                    new Skill { Id = 33, KnowledgeAreaId = 5, Name = "Windows" },
                    new Skill { Id = 34, KnowledgeAreaId = 5, Name = "iOS" },
                    new Skill { Id = 35, KnowledgeAreaId = 5, Name = "Android"}
                );
            
            var user1_Guid = "7f171733-5277-434f-88f2-6ee032e600c4";
            var user2_Guid = "878614e6-8390-4a03-938b-bfd081dbf944";

            modelBuilder.Entity<UserEvaluetedSkill>()
                .HasData(
                   new UserEvaluetedSkill { Id = 1, UserId = user1_Guid, SkillId = 1, Grade = 1 },
                   new UserEvaluetedSkill { Id = 2, UserId = user1_Guid, SkillId = 2, Grade = 2 },
                   new UserEvaluetedSkill { Id = 3, UserId = user1_Guid, SkillId = 3, Grade = 3 },
                   new UserEvaluetedSkill { Id = 4, UserId = user1_Guid, SkillId = 4, Grade = 4 },

                   new UserEvaluetedSkill { Id = 5, UserId = user2_Guid, SkillId = 5, Grade = 2 },
                   new UserEvaluetedSkill { Id = 6, UserId = user2_Guid, SkillId = 6, Grade = 5 },
                   new UserEvaluetedSkill { Id = 7, UserId = user2_Guid, SkillId = 7, Grade = 4 },
                   new UserEvaluetedSkill { Id = 8, UserId = user2_Guid, SkillId = 8, Grade = 1 }
               );

        }
    }
}
