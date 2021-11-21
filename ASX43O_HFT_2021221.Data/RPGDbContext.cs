using ASX43O_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Data
{
    public class RPGDbContext : DbContext
    {
        public virtual DbSet<PlayerCharacter> Characters { get; set; }
        public virtual DbSet<PlayerRace> Races { get; set; }
        public virtual DbSet<PlayerClass> Classes { get; set; }
        public virtual DbSet<PlayerSkill> Skills { get; set; }
        public virtual DbSet<PlayerItem> Inventory { get; set; }

        public RPGDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\RPGDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerCharacter>(entity =>
            {
                entity
                .HasOne(player => player.Race)
                .WithMany(race => race.Characters)
                .HasForeignKey(player => player.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                entity
                .HasOne(player => player.Class)
                .WithMany(pclass => pclass.Characters)
                .HasForeignKey(player => player.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PlayerSkill>(e =>
            {
                e
                .HasOne(skill => skill.Owner)
                .WithMany(player => player.Skills)
                .HasForeignKey(skill => skill.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<PlayerItem>(e =>
            {
                e
                .HasOne(skill => skill.Owner)
                .WithMany(player => player.Items)
                .HasForeignKey(skill => skill.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            var human = new PlayerRace() { Id = 1, Name = "Human" };
            var elf = new PlayerRace() { Id = 2, Name = "Elf" };
            var orc = new PlayerRace() { Id = 3, Name = "Orc" };

            var warrior = new PlayerClass() { Id = 1, Name = "Warrior" , ReqRaceId = elf.Id};
            var shaman = new PlayerClass() { Id = 2, Name = "Shaman", ReqRaceId = orc.Id };
            var wizard = new PlayerClass() { Id = 3, Name = "Wizard", ReqRaceId = human.Id };
            var barbarian = new PlayerClass() { Id = 4, Name = "Barbarian", ReqRaceId = orc.Id };
            var thief = new PlayerClass() { Id = 5, Name = "Thief", ReqRaceId = human.Id };
            var knight = new PlayerClass() { Id = 6, Name = "Knight", ReqRaceId = human.Id };
            var assassin = new PlayerClass() { Id = 7, Name = "Assassin", ReqRaceId = elf.Id };
            var archer = new PlayerClass() { Id = 8, Name = "Archer", ReqRaceId = elf.Id };
            var witch = new PlayerClass() { Id = 9, Name = "Witch", ReqRaceId = human.Id };

            var robin = new PlayerCharacter() { Id = 1, RaceId = human.Id, Name = "Robin", ClassId = thief.Id , CharacterLevel = 3};
            var brog = new PlayerCharacter() { Id = 2, RaceId = orc.Id, Name = "Brog", ClassId = barbarian.Id , CharacterLevel = 4};
            var legolas = new PlayerCharacter() { Id = 3, RaceId = elf.Id, Name = "Legolas", ClassId = archer.Id, CharacterLevel = 8};
            var alira = new PlayerCharacter() { Id = 4, RaceId = human.Id, Name = "Alira", ClassId = witch.Id , CharacterLevel = 6};
            var zuluhed = new PlayerCharacter() { Id = 5, RaceId = orc.Id, Name = "Zuluhed", ClassId = shaman.Id , CharacterLevel = 10};
            var khainite = new PlayerCharacter() { Id = 6, RaceId = elf.Id, Name = "Khainite", ClassId = assassin.Id, CharacterLevel = 10};


            var characters = new List<PlayerCharacter>() {
                robin, brog, legolas, alira, zuluhed, khainite
            };

            var skillFight = new PlayerSkill() { Id = 1, Name = "Fegyverhasználat", ReqLevel = 1, RequiredClassId = warrior.Id };
            var skillArchery = new PlayerSkill() { Id = 2, Name = "Íjászat", ReqLevel = 1, RequiredClassId = archer.Id };
            var skillCurse = new PlayerSkill() { Id = 3, Name = "Átkok", ReqLevel = 4, RequiredClassId = witch.Id };
            var skillPoison = new PlayerSkill() { Id = 4, Name = "Méregkeverés", ReqLevel = 3, RequiredClassId = assassin.Id };
            var skillHeal = new PlayerSkill() { Id = 5, Name = "Gyógyítás", ReqLevel = 3, RequiredClassId = shaman.Id };
            var skillBlock = new PlayerSkill() { Id = 6, Name = "Pajzshasználat", ReqLevel = 2, RequiredClassId = knight.Id };
            var skillPortal = new PlayerSkill() { Id = 7, Name = "Portál", ReqLevel = 20, RequiredClassId = wizard.Id };
            var skillSteal = new PlayerSkill() { Id = 8, Name = "Lopás", ReqLevel = 2, RequiredClassId = thief.Id };

            var skills = new List<PlayerSkill>() { 
                skillFight, skillArchery, skillCurse, skillPoison, skillHeal, skillBlock, skillPortal, skillSteal
            };

            var sword = new PlayerItem() { Id = 1, Name = "Shortsword", OwnerId = khainite.Id , ReqLevel = 1};
            var bow = new PlayerItem() { Id = 1, Name = "Elven Bow", OwnerId = legolas.Id, ReqLevel = 4 };
            var dagger = new PlayerItem() { Id = 1, Name = "Poison Dagger", OwnerId = khainite.Id, ReqLevel = 2 };
            var cloak = new PlayerItem() { Id = 1, Name = "Cloak", OwnerId = robin.Id, ReqLevel = 1 };
            var shield = new PlayerItem() { Id = 1, Name = "A wooden door", OwnerId = brog.Id, ReqLevel = 1 };
            var items = new List<PlayerItem>() {
                sword, bow, dagger, cloak, shield
            };


            modelBuilder.Entity<PlayerCharacter>().HasData(characters);
            modelBuilder.Entity<PlayerRace>().HasData(human, elf, orc);
            modelBuilder.Entity<PlayerClass>().HasData(warrior,shaman,wizard,barbarian,thief,knight,assassin,archer,witch);
            modelBuilder.Entity<PlayerItem>().HasData(items);
            modelBuilder.Entity<PlayerSkill>().HasData(skills);
        }

    }
}
