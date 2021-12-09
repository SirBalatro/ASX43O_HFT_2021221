using ASX43O_HFT_2021221.Logic;
using ASX43O_HFT_2021221.Models;
using ASX43O_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Test
{
    [TestFixture]
    class NonCrudTests
    {
        Mock<ICharacterRepository> mockCharRepo = new Mock<ICharacterRepository>();
        Mock<IRaceRepository> mockRaceRepo = new Mock<IRaceRepository>();
        Mock<IClassRepository> mockClassRepo = new Mock<IClassRepository>();
        Mock<IItemRepository> mockItemRepo = new Mock<IItemRepository>();
        INonCrudLogic Logic;

        public NonCrudTests()
        {
            Logic = new NonCrudLogic(mockCharRepo.Object, mockRaceRepo.Object, mockClassRepo.Object, mockItemRepo.Object);
            
            //SampleData here (from seed data)            
                var human = new PlayerRace() { Id = 1, Name = "Human" };
                var elf = new PlayerRace() { Id = 2, Name = "Elf" };
                var orc = new PlayerRace() { Id = 3, Name = "Orc" };

                var warrior = new PlayerClass() { Id = 1, Name = "Warrior" };
                var shaman = new PlayerClass() { Id = 2, Name = "Shaman" };
                var wizard = new PlayerClass() { Id = 3, Name = "Wizard" };
                var barbarian = new PlayerClass() { Id = 4, Name = "Barbarian" };
                var thief = new PlayerClass() { Id = 5, Name = "Thief" };
                var knight = new PlayerClass() { Id = 6, Name = "Knight" };
                var assassin = new PlayerClass() { Id = 7, Name = "Assassin" };
                var archer = new PlayerClass() { Id = 8, Name = "Archer" };
                var witch = new PlayerClass() { Id = 9, Name = "Witch" };

                var robin = new PlayerCharacter() { Id = 1, RaceId = human.Id, Name = "Robin", ClassId = thief.Id, CharacterLevel = 3 };
                var brog = new PlayerCharacter() { Id = 2, RaceId = orc.Id, Name = "Brog", ClassId = barbarian.Id, CharacterLevel = 4 };
                var legolas = new PlayerCharacter() { Id = 3, RaceId = elf.Id, Name = "Legolas", ClassId = archer.Id, CharacterLevel = 8 };
                var alira = new PlayerCharacter() { Id = 4, RaceId = human.Id, Name = "Alira", ClassId = witch.Id, CharacterLevel = 7 };
                var zuluhed = new PlayerCharacter() { Id = 5, RaceId = orc.Id, Name = "Zuluhed", ClassId = shaman.Id, CharacterLevel = 10 };
                var khainite = new PlayerCharacter() { Id = 6, RaceId = elf.Id, Name = "Khainite", ClassId = assassin.Id, CharacterLevel = 10 };

                var sword = new PlayerItem() { Id = 1, Name = "Shortsword", OwnerId = khainite.Id, ReqLevel = 1 };
                var bow = new PlayerItem() { Id = 2, Name = "Elven Bow", OwnerId = legolas.Id, ReqLevel = 4 };
                var dagger = new PlayerItem() { Id = 3, Name = "Poison Dagger", OwnerId = khainite.Id, ReqLevel = 2 };
                var cloak = new PlayerItem() { Id = 4, Name = "Cloak", OwnerId = robin.Id, ReqLevel = 1 };
                var shield = new PlayerItem() { Id = 5, Name = "A wooden door", OwnerId = brog.Id, ReqLevel = 1 };

                var races = new HashSet<PlayerRace>() {
                    human, elf, orc
                };
                var classes = new HashSet<PlayerClass>() {
                    warrior, shaman, wizard, barbarian, thief, knight, assassin, archer, witch
                };
                var characters = new HashSet<PlayerCharacter>() {
                    robin, brog, legolas, alira, zuluhed, khainite
                };
                var items = new HashSet<PlayerItem>() {
                    sword, bow, dagger, cloak, shield
                };
            

            mockCharRepo.Setup(repo => repo.Create(It.IsAny<PlayerCharacter>()));
            mockCharRepo.Setup(repo => repo.GetAll()).Returns(characters);
            mockCharRepo.Setup(repo => repo.GetOne(1)).Returns(robin);

            mockRaceRepo.Setup(repo => repo.Create(It.IsAny<PlayerRace>()));
            mockRaceRepo.Setup(repo => repo.GetAll()).Returns(races);
            mockRaceRepo.Setup(repo => repo.GetOne(1)).Returns(human);

            mockClassRepo.Setup(repo => repo.Create(It.IsAny<PlayerClass>()));
            mockClassRepo.Setup(repo => repo.GetAll()).Returns(classes);
            mockClassRepo.Setup(repo => repo.GetOne(1)).Returns(warrior);

            mockItemRepo.Setup(repo => repo.Create(It.IsAny<PlayerItem>()));
            mockItemRepo.Setup(repo => repo.GetAll()).Returns(items);
            mockItemRepo.Setup(repo => repo.GetOne(1)).Returns(sword);
        }

        [Test]
        public void CharacterWithBestItemTest()
        {
            var q = Logic.CharacterWithBestItem();
            Assert.That(q.Id.Equals(3));
        }

        [Test]
        public void CharacterWithItemTest()
        {
            var q = Logic.CharacterWithItem(5);
            Assert.That(q.Id.Equals(2));
        }

        [Test]
        public void ItemsUsedByClass()
        {
            var q = Logic.ItemsUsedByClass(7);
            Assert.That(q.Count().Equals(2));
        }
    }
}
