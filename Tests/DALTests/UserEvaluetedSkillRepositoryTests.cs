using DAL;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.DALTests
{
    [TestFixture]
    class UserEvaluetedSkillRepositoryTests
    {
        const string user1Guid = "49947400-5E0A-43B5-915B-71AB2B081D93";
        const string user2Guid = "E167DAEB-E4B5-4145-B105-626E2FD480DA";

        [Test]
        public async Task UserEvaluetedSkillRepository_GetAllAsync_ReturnsAllValues()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var userSkillRepository = new UserEvaluetedSkillRepository(context);

                //Act
                var skills = await userSkillRepository.GetAllAsync();

                //Assert
                Assert.AreEqual(8, skills.Count());
            }
        }

        [Test]
        public async Task UserEvaluetedSkillRepository_GetAllWithDetailsAsync_ReturnsAllValuesWithDetails()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var userSkillRepository = new UserEvaluetedSkillRepository(context);

                //Act
                var skills = await userSkillRepository.GetAllWithDetailsAsync();

                //Assert
                Assert.AreEqual(8, skills.Count());
                foreach (var skill in skills)
                {
                    Assert.AreEqual(skill.Skill.KnowledgeArea.Name, "Programming Languages");
                }
            }
        }


        [Test]
        public async Task UserEvaluetedSkillRepository_GetSkillsByUserIdAsync_ReturnsUserSkillsWithDetails()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var userSkillRepository = new UserEvaluetedSkillRepository(context);

                //Act
                var userSkills = await userSkillRepository.GetSkillsByUserIdAsync(user1Guid);

                //Assert
                Assert.AreEqual(4, userSkills.Count());
            }
        }

        [Test]
        public async Task UserEvaluetedSkillRepository_AddAsync_AddsValueToDB()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var userSkillRepository = new UserEvaluetedSkillRepository(context);
                var newSkill = new UserEvaluetedSkill{ UserId = user1Guid, SkillId = 11, Grade = 5 };

                //Act
                await userSkillRepository.AddAsync(newSkill);
                await context.SaveChangesAsync();
                var userSkills = await userSkillRepository.GetSkillsByUserIdAsync(user1Guid);

                //Assert
                var addedSkill = userSkills.OrderBy(x => x.Id).Last();
                Assert.AreEqual(5, userSkills.Count());
                Assert.AreEqual(newSkill.SkillId, addedSkill.SkillId);
                Assert.AreEqual(newSkill.Grade, addedSkill.Grade);
            }
        }

        [Test]
        public async Task UserEvaluetedSkillRepository_Update_UpdatesValueToDB()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var userSkillRepository = new UserEvaluetedSkillRepository(context);

                //Act
                var skill = await userSkillRepository.GetByIdAsync(1);
                skill.Grade = 5;
                userSkillRepository.Update(skill);
                context.SaveChanges();
                var updSkill = await userSkillRepository.GetByIdAsync(1);

                //Assert
                Assert.AreEqual(5, updSkill.Grade);
            }
        }

        [Test]
        public async Task UserEvaluetedSkillRepository_DeleteAsyncById_RemovesEntity()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var userSkillRepository = new UserEvaluetedSkillRepository(context);

                //Act
                await userSkillRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();
                var skills = await userSkillRepository.GetAllAsync();

                //Assert
                Assert.AreEqual(7, skills.Count());
            }
        }
    }
}
