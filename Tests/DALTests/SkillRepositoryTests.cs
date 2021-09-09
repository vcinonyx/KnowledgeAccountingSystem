using DAL;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.DALTests
{
    [TestFixture]
    class SkillRepositoryTests
    {
        [Test]
        public async Task SkillRepository_GetAllAsync_ReturnsAllValues()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var skillRepository = new SkillRepository(context);

                //Act
                var skills = await skillRepository.GetAllAsync();

                //Assert
                Assert.AreEqual(35, skills.Count());
            }
        }

        [Test]
        public async Task SkillRepository_GetByIdAsync_ReturnsValue()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);

                var skill = await skillRepository.GetByIdAsync(1);

                Assert.AreEqual(1, skill.Id);
                Assert.AreEqual("C#", skill.Name);
                Assert.AreEqual("Programming Languages", skill.KnowledgeArea.Name);
            }
        }

        [Test]
        public async Task SkillRepository_DeleteByIdAsync_DeletesEntity()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);

                await skillRepository.DeleteByIdAsync(1);
                await skillRepository.DeleteByIdAsync(2);
                await context.SaveChangesAsync();
                var skills = await skillRepository.GetAllAsync();

                Assert.AreEqual(33, skills.Count());
            }
        }

        [Test]
        public async Task SkillRepository_Update_UpdatesEntity()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);
                var skill = new Skill { Id = 1, Name = "Scala", KnowledgeAreaId = 1};

                skillRepository.Update(skill);
                context.SaveChanges();
                var actual = await skillRepository.GetByIdAsync(1);

                Assert.AreEqual(skill.Id, actual.Id);
                Assert.AreEqual(skill.Name, actual.Name);
            }
        }

        [Test]
        public async Task SkillRepository_AddAsync_AddsValueToDB()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var skillRepository = new SkillRepository(context);
                var skill = new Skill { Id = 36, Name = "Scala", KnowledgeAreaId = 1 };

                await skillRepository.AddAsync(skill);
                await context.SaveChangesAsync();
                var skills = await skillRepository.GetAllAsync();

                Assert.AreEqual(36, skills.Count());
            }
        }
    }
}
