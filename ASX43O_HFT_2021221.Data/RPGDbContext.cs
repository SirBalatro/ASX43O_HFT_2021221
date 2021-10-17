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
                .HasOne(PlayerCharacter => PlayerCharacter.Id)
                .WithOne(PlayerRace => PlayerRace.Id)
                .HasForeignKey(PlayerCharacter => PlayerCharacter.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            PlayerRace human = new PlayerRace() { Id = 1 };

            PlayerCharacter first = new PlayerCharacter() { Id = 1, RaceId = 1, Name = "First", ClassId = 1 };
        }

    }
}
