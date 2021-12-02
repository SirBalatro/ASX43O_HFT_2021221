using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public class PlayerItemRepo : Repository<PlayerItem>, IItemRepository
    {
        public PlayerItemRepo(RPGDbContext db) : base(db)
        {

        }
        public void ChangeReqLevel(int id, int lvl)
        {
            var p = GetOne(id);
            p.ReqLevel = lvl;
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            db.Set<PlayerItem>().Remove(GetOne(id));
            db.SaveChanges();
        }

        public override PlayerItem GetOne(int id)
        {
            return db.Inventory.FirstOrDefault(c => c.Id == id);
        }
    }
}
