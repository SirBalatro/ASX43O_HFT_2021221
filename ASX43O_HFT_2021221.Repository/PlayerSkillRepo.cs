using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public class PlayerSkillRepo : Repository<PlayerSkill>, ISkillRepository
    {
        public PlayerSkillRepo(RPGDbContext db) : base(db)
        {
        }
        public override PlayerSkill GetOne(int id)
        {
            return db.Skills.FirstOrDefault(s => s.Id == id);
        }
        public override void Delete(int id)
        {
            db.Remove(GetOne(id));
            db.SaveChanges();
        }

        public void ChangeReqLevel(int id, int lvl)
        {
            var p = GetOne(id);
            p.ReqLevel = lvl;
            db.SaveChanges();
        }
    }
}
