using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public class PlayerRaceRepo : Repository<PlayerRace>, IRaceRepository
    {
        public PlayerRaceRepo(RPGDbContext db) : base(db)
        {
        }
        public override PlayerRace GetOne(int id)
        {
            return db.Races.FirstOrDefault(race => race.Id == id);
        }
        public override void Delete(int id)
        {
            db.Set<PlayerRace>().Remove(GetOne(id));
            db.SaveChanges();
        }

        public void ChangeName(int id, string name)
        {
            var p = GetOne(id);
            p.Name = name;
            db.SaveChanges();
        }
    }
}
