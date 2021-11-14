using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public class PlayerClassRepo : IClassRepository
    {
        RPGDbContext db;
        public PlayerClassRepo(RPGDbContext db)
        {
            this.db = db;
        }
        public void Create(PlayerClass c)
        {
            db.Classes.Add(c);
            db.SaveChanges();
        }
        public PlayerClass Read(int id)
        {
            return db.Classes.FirstOrDefault(c => c.Id == id);
        }
        public IQueryable<PlayerClass> ReadAll()
        {
            return db.Classes;
        }
        public void Update(PlayerClass c)
        {
            var x = Read(c.Id);
            x.Name = c.Name;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
