using DAL;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.DALTests
{
    [TestFixture]
    class KnowledgeAreaRepositoryTests
    {
        [Test]
        public async Task KnowledgeAreaRepository_GetAllAsync_ReturnsAllValues()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var knowledgeAreaRepository = new KnowledgeAreaRepository(context);
                
                //Act
                var knowledgeAreas = await knowledgeAreaRepository.GetAllAsync();
                
                //Assert
                Assert.AreEqual(5, knowledgeAreas.Count());
            }
        }

        [Test]
        public async Task KnowledgeAreaRepository_GetByIdAsync_ReturnsValue()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeAreaRepository = new KnowledgeAreaRepository(context);

                var knowledgeArea = await knowledgeAreaRepository.GetByIdAsync(1);
                
                Assert.AreEqual(1, knowledgeArea.Id);
                Assert.AreEqual("Programming Languages", knowledgeArea.Name);
            }
        }

        [Test]
        public async Task KnowledgeAreaRepository_AddAsync_AddsValueToDB()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeAreaRepository = new KnowledgeAreaRepository(context);
                var knowledgeArea = new KnowledgeArea { Id = 7 };

                await knowledgeAreaRepository.AddAsync(knowledgeArea);
                await context.SaveChangesAsync();

                Assert.AreEqual(6, context.KnowledgeAreas.Count());
            }
        }

        [Test]
        public async Task KnowledgeAreaRepository_DeleteByIdAsync_DeletesEntity()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeAreaRepository = new KnowledgeAreaRepository(context);

                await knowledgeAreaRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();

                Assert.AreEqual(4, context.KnowledgeAreas.Count());
            }
        }

        [Test]
        public async Task KnowledgeAreaRepository_Update_UpdatesEntity()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                var knowledgeAreaRepository = new KnowledgeAreaRepository(context);
                var updateKnowledgeArea = new KnowledgeArea { Id = 1, Name = "Soft Skills" };

                knowledgeAreaRepository.Update(updateKnowledgeArea);
                context.SaveChanges();
                var actual = await knowledgeAreaRepository.GetByIdAsync(1);

                Assert.AreEqual(1, actual.Id);
                Assert.AreEqual(updateKnowledgeArea.Name, actual.Name);
            }
        }
    }
}
