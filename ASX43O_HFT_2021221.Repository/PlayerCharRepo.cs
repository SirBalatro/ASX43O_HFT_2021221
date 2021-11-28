using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    public class PlayerCharRepo : Repository<PlayerCharacter>, ICharacterRepository
    {
        public PlayerCharRepo(RPGDbContext db) : base(db) 
        { 

        }
        public override PlayerCharacter GetOne(int id)
        {
            return db.Characters.FirstOrDefault(player => player.Id == id);
        }
        public override void Delete(int id)
        {
            db.Characters.Remove(GetOne(id));
            db.SaveChanges();
        }

        public void LevelUp(int id)
        {
            var character = GetOne(id);
            character.CharacterLevel++;
            db.SaveChanges();
        }

        public void ChangeName(int id, string name)
        {
            var character = GetOne(id);
            character.Name = name;
            db.SaveChanges();
        }
    }
}
