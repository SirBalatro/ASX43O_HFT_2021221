using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public class PlayerClassRepo : Repository<PlayerClass>, IClassRepository
    {
        public PlayerClassRepo(RPGDbContext db) : base(db)
        {

        }
        public override PlayerClass GetOne(int id)
        {
            return db.Classes.FirstOrDefault(c => c.Id == id);
        }
        public override void Delete(int id)
        {
            db.Set<PlayerClass>().Remove(GetOne(id));
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
