using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    class PlayerRaceRepo : IRaceRepository
    {
        RPGDbContext db;
        public PlayerRaceRepo(RPGDbContext db)
        {
            this.db = db;
        }
        public void Create(PlayerRace race)
        {
            db.Races.Add(race);
            db.SaveChanges();
        }
        public PlayerRace Read(int id)
        {
            return db.Races.FirstOrDefault(race => race.Id == id);
        }
        public IQueryable<PlayerRace> ReadAll()
        {
            return db.Races;
        }
        public void Update(PlayerRace race)
        {
            var x = Read(race.Id);
            x.Name = race.Name;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
