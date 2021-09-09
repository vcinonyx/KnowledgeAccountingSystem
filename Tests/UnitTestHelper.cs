using AutoMapper;
using BLL;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Tests
{
   internal static class UnitTestHelper
   {
        public static DbContextOptions<AccountingSystemDbContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<AccountingSystemDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new AccountingSystemDbContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        public static void SeedData(AccountingSystemDbContext context)
        {
            context.KnowledgeAreas.Add(new KnowledgeArea { Id = 1, Name = "Programming Languages" });
            context.KnowledgeAreas.Add(new KnowledgeArea { Id = 2, Name = "Source Control" });
            context.KnowledgeAreas.Add(new KnowledgeArea { Id = 3, Name = "IDEs (Integrated Development Environment)" });
            context.KnowledgeAreas.Add(new KnowledgeArea { Id = 4, Name = "Databases" });
            context.KnowledgeAreas.Add(new KnowledgeArea { Id = 5, Name = "Operating Systems" });

            context.Skills.AddRange(
                new Skill { Id = 1, KnowledgeAreaId = 1, Name = "C#" },
                new Skill { Id = 2, KnowledgeAreaId = 1, Name = "C/C++" },
                new Skill { Id = 3, KnowledgeAreaId = 1, Name = "Java" },
                new Skill { Id = 4, KnowledgeAreaId = 1, Name = "Python" },
                new Skill { Id = 5, KnowledgeAreaId = 1, Name = "JavaScript" },
                new Skill { Id = 6, KnowledgeAreaId = 1, Name = "TypeScript" },
                new Skill { Id = 7, KnowledgeAreaId = 1, Name = "PHP" },
                new Skill { Id = 8, KnowledgeAreaId = 1, Name = "Go" },
                new Skill { Id = 9, KnowledgeAreaId = 1, Name = "Kotlin" },
                new Skill { Id = 10, KnowledgeAreaId = 1, Name = "Swift" },

                new Skill { Id = 11, KnowledgeAreaId = 2, Name = "Git" },
                new Skill { Id = 12, KnowledgeAreaId = 2, Name = "Mercurial" },
                new Skill { Id = 13, KnowledgeAreaId = 2, Name = "Perforce Helix Core" },

                new Skill { Id = 14, KnowledgeAreaId = 3, Name = "Visual Studio" },
                new Skill { Id = 15, KnowledgeAreaId = 3, Name = "Eclipse" },
                new Skill { Id = 16, KnowledgeAreaId = 3, Name = "Visual Studio Code" },
                new Skill { Id = 17, KnowledgeAreaId = 3, Name = "Android Studio" },
                new Skill { Id = 18, KnowledgeAreaId = 3, Name = "PyCharm" },
                new Skill { Id = 19, KnowledgeAreaId = 3, Name = "Rider" },
                new Skill { Id = 20, KnowledgeAreaId = 3, Name = "NetBeans" },
                new Skill { Id = 21, KnowledgeAreaId = 3, Name = "Xcode" },

                new Skill { Id = 22, KnowledgeAreaId = 4, Name = "SQL" },
                new Skill { Id = 23, KnowledgeAreaId = 4, Name = "T-SQL" },
                new Skill { Id = 24, KnowledgeAreaId = 4, Name = "MySQL" },
                new Skill { Id = 25, KnowledgeAreaId = 4, Name = "Oracle" },
                new Skill { Id = 26, KnowledgeAreaId = 4, Name = "PostgreSQL" },
                new Skill { Id = 27, KnowledgeAreaId = 4, Name = "Microsoft SQL Server" },
                new Skill { Id = 28, KnowledgeAreaId = 4, Name = "NoSQL" },
                new Skill { Id = 29, KnowledgeAreaId = 4, Name = "MongoDB" },
                new Skill { Id = 30, KnowledgeAreaId = 4, Name = "Redis" },

                new Skill { Id = 31, KnowledgeAreaId = 5, Name = "Linux" },
                new Skill { Id = 32, KnowledgeAreaId = 5, Name = "MacOS" },
                new Skill { Id = 33, KnowledgeAreaId = 5, Name = "Windows" },
                new Skill { Id = 34, KnowledgeAreaId = 5, Name = "iOS" },
                new Skill { Id = 35, KnowledgeAreaId = 5, Name = "Android" }
                );

            var user1_Guid = Guid.NewGuid().ToString();
            var user2_Guid = Guid.NewGuid().ToString();

            context.UserSkillsCards.AddRange(
                new UserSkillsCard { Id = 1, UserId = user1_Guid },
                new UserSkillsCard { Id = 2, UserId = user2_Guid }
            );

            context.UserEvaluetedSkills.AddRange(
                new UserEvaluetedSkill { Id = 1, UserSkillsCardId = 1, SkillId = 1, Grade = 1 },
                new UserEvaluetedSkill { Id = 2, UserSkillsCardId = 1, SkillId = 2, Grade = 2 },
                new UserEvaluetedSkill { Id = 3, UserSkillsCardId = 1, SkillId = 3, Grade = 3 },
                new UserEvaluetedSkill { Id = 4, UserSkillsCardId = 1, SkillId = 4, Grade = 4},

                new UserEvaluetedSkill { Id = 5, UserSkillsCardId = 2, SkillId = 5, Grade = 2 },
                new UserEvaluetedSkill { Id = 6, UserSkillsCardId = 2, SkillId = 6, Grade = 5 },
                new UserEvaluetedSkill { Id = 7, UserSkillsCardId = 2, SkillId = 7, Grade = 4 },
                new UserEvaluetedSkill { Id = 8, UserSkillsCardId = 2, SkillId = 8, Grade = 1 }
            );

            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }

    }
}