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
    class CrudTests
    {
        Mock<ICharacterRepository> mockCharRepo = new Mock<ICharacterRepository>();
        IPlayerCharacterLogic CharLogic;
        Mock<IRaceRepository> mockRaceRepo = new Mock<IRaceRepository>();
        IPlayerRaceLogic RaceLogic;
        Mock<IClassRepository> mockClassRepo = new Mock<IClassRepository>();
        IPlayerClassLogic ClassLogic;
        Mock<IItemRepository> mockItemRepo = new Mock<IItemRepository>();
        IPlayerItemLogic ItemLogic;

        public CrudTests()
        {
            CharLogic = new PlayerCharacterLogic(mockCharRepo.Object);
            RaceLogic = new PlayerRaceLogic(mockRaceRepo.Object);
            ItemLogic = new PlayerItemLogic(mockItemRepo.Object);
            ClassLogic = new PlayerClassLogic(mockClassRepo.Object);
        }

        [TestCase(1)]
        [TestCase(0)]
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

        [TestCase("ember")]
        public void RaceCreateValid(string name)
        {
            Assert.That(
                () =>
                {
                    RaceLogic.Create(new PlayerRace() {Id = 2, Name = name });
                },
                Throws.Nothing
                );
        }

        [TestCase("")]
        [TestCase(null)]
        public void RaceCreateInvalid(string name)
        {
            Assert.That(
                () =>
                {
                    RaceLogic.Create(new PlayerRace() { Id = 2, Name = name });
                },
                Throws.Exception
                );
        }

        [TestCase("valid", 1)]
        [TestCase("valid", 0)]
        public void ItemCreateValid(string name, int lvl)
        {
            Assert.That(
                () =>
                {
                    ItemLogic.Create(new PlayerItem() { Name = name, Id = 1, ReqLevel = lvl});
                },
                Throws.Nothing
                );
        }

        [TestCase("", 1)]
        [TestCase(null, 1)]
        public void ItemCreateInvalid(string name, int lvl)
        {
            Assert.That(
                () =>
                {
                    ItemLogic.Create(new PlayerItem() { Name = name, Id = 1, ReqLevel = lvl });
                },
                Throws.Exception
                );
        }

    }
}
