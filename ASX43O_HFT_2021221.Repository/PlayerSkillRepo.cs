using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public class PlayerSkillRepo : ISkillRepository
    {
        RPGDbContext db;
        public PlayerSkillRepo(RPGDbContext db)
        {
            this.db = db;
        }
        public void Create(PlayerSkill s)
        {
            db.Skills.Add(s);
            db.SaveChanges();
        }
        public PlayerSkill Read(int id)
        {
            return db.Skills.FirstOrDefault(s => s.Id == id);
        }
        public IQueryable<PlayerSkill> ReadAll()
        {
            return db.Skills;
        }
        public void Update(PlayerSkill s)
        {
            var x = Read(s.Id);
            x.Name = s.Name;
            x.OwnerId = s.OwnerId;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
