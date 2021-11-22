using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASX43O_HFT_2021221.Logic;
using ASX43O_HFT_2021221.Repository;
using ASX43O_HFT_2021221.Models;
using Moq;
using NUnit.Framework;

namespace ASX43O_HFT_2021221.Test
{
    class MockTests
    {
        Mock<ICharacterRepository> mockCharRepo = new Mock<ICharacterRepository>();
        IPlayerCharacterLogic CharLogic;

        public MockTests()
        {
            CharLogic = new PlayerCharacterLogic(mockCharRepo.Object);
            PlayerRace elf = new PlayerRace() { Id = 1, Name = "Elf" };

            mockCharRepo.Setup(repo => repo.Create(It.IsAny<PlayerCharacter>()));
            mockCharRepo.Setup(repo => repo.GetAll()).Returns(
                new List<PlayerCharacter>
                {
                    new PlayerCharacter()
                    {
                        Name = "Legolas",
                        Id = 1,
                        CharacterLevel = 3,
                        RaceId = elf.Id,
                    }
                }.AsQueryable()
                ) ;
            mockCharRepo.Setup(repo => repo.GetOne(1)).Returns(
                    new PlayerCharacter()
                    {
                        Name = "Legolas",
                        Id = 1,
                        CharacterLevel = 3,
                        RaceId = elf.Id,
                    }
                );
        }

        [TestCase(1)]
        public void PlayerCreateValid(int lvl)
        {
            Assert.That(
                () =>
                {
                    CharLogic.Create(new PlayerCharacter() { CharacterLevel = lvl, Id = 2, Name = "jani" });
                },
                Throws.Nothing
                );
        }

        [TestCase(-1)]
        public void PlayerCreateInvalid(int lvl)
        {
            Assert.That(
                () =>
                {
                    CharLogic.Create(new PlayerCharacter() { CharacterLevel = lvl, Id = 3, Name = "jani" });
                },
                Throws.Exception
                );
        }

        [Test]
        public void PlayerLevelUp()
        {
            var v = CharLogic.GetOne(1);
            CharLogic.LevelUp(1);
            Assert.That(v.CharacterLevel == 3);
        }

    }
}
