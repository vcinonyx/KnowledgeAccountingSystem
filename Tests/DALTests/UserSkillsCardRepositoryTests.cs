using DAL;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.DALTests
{
    [TestFixture]
    class UserSkillsCardRepositoryTests
    {
        [Test]
        public async Task UserSkillsCardRepository_GetAllAsync_ReturnsAllValues()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var cardRepository = new UserSkillsCardRepository(context);

                //Act
                var cards = await cardRepository.GetAllAsync();

                //Assert
                Assert.AreEqual(2, cards.Count());
            }
        }

        [Test]
        public async Task UserSkillsCardRepository_GetAllWithDetailsAsync_ReturnsAllValuesWithDetails()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var cardRepository = new UserSkillsCardRepository(context);

                //Act
                var cards = await cardRepository.GetAllWithDetailsAsync();

                //Assert
                Assert.AreEqual(2, cards.Count());
                Assert.AreEqual(4, cards.ElementAt(0).UserSkills.Count());
                Assert.AreEqual(4, cards.ElementAt(1).UserSkills.Count());
            }
        }

        [Test]
        public async Task UserSkillsCardRepository_AddAsync_AddsValueToDB()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var cardRepository = new UserSkillsCardRepository(context);
                var card = new UserSkillsCard { Id = 3, UserId = Guid.NewGuid().ToString() };

                //Act
                await cardRepository.AddAsync(card);
                await context.SaveChangesAsync();
                var cards = await cardRepository.GetAllAsync();

                //Assert
                Assert.AreEqual(3, cards.Count());
            }
        }


        [Test]
        public async Task UserSkillsCardRepository_DeleteAsyncById_RemovesEntity()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var cardRepository = new UserSkillsCardRepository(context);

                //Act
                await cardRepository.DeleteByIdAsync(1);
                await context.SaveChangesAsync();

                var cards = await cardRepository.GetAllAsync();

                //Assert
                Assert.AreEqual(1, cards.Count());
            }
        }

        [Test]
        public async Task UserSkillsCardRepository_DeleteAsync_RemovesEntity()
        {
            using (var context = new AccountingSystemDbContext(UnitTestHelper.GetUnitTestDbOptions()))
            {
                //Arrange
                var cardRepository = new UserSkillsCardRepository(context);
                var card = new UserSkillsCard { Id = 1 };

                //Act
                await cardRepository.DeleteAsync(card);
                await context.SaveChangesAsync();

                var cards = await cardRepository.GetAllAsync();

                //Assert
                Assert.AreEqual(1, cards.Count());
            }
        }

    }
}
