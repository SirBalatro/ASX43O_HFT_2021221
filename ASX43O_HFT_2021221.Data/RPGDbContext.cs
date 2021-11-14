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
            var warrior = new PlayerClass() { Id = 1, Name = "Warrior" };

            var first = new PlayerCharacter() { Id = 1, RaceId = human.Id, Name = "First", ClassId = warrior.Id };
            var characters = new List<PlayerCharacter>() {
                first
            };

            PlayerSkill skillFighting = new PlayerSkill() { Id = 1, Name = "Fegyverhasználat", OwnerId = first.Id };
            var skills = new List<PlayerSkill>() { 
                skillFighting
            };

            PlayerItem sword = new PlayerItem() { Id = 1, Name = "Kard", OwnerId = first.Id };
            var items = new List<PlayerItem>() {
                sword
            };


            modelBuilder.Entity<PlayerCharacter>().HasData(characters);
            modelBuilder.Entity<PlayerRace>().HasData(human);
            modelBuilder.Entity<PlayerClass>().HasData(warrior);
            modelBuilder.Entity<PlayerItem>().HasData(items);
            modelBuilder.Entity<PlayerSkill>().HasData(skills);
        }

    }
}
