using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    class PlayerItemRepo : IItemRepository
    {
        RPGDbContext db;
        public PlayerItemRepo(RPGDbContext db)
        {
            this.db = db;
        }
        public void Create(PlayerItem i)
        {
            db.Inventory.Add(i);
            db.SaveChanges();
        }
        public PlayerItem Read(int id)
        {
            return db.Inventory.FirstOrDefault(i => i.Id == id);
        }
        public IQueryable<PlayerItem> ReadAll()
        {
            return db.Inventory;
        }
        public void Update(PlayerItem i)
        {
            var x = Read(i.Id);
            x.Name = i.Name;
            x.OwnerId = i.OwnerId;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
