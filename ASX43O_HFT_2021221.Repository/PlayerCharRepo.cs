using ASX43O_HFT_2021221.Data;
using ASX43O_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Repository
{
    class PlayerCharRepo : ICharacterRepository
    {
        RPGDbContext db;
        public PlayerCharRepo(RPGDbContext db)
        {
            this.db = db;
        }
        public void Create(PlayerCharacter player)
        {
            db.Characters.Add(player);
            db.SaveChanges();
        }
        public PlayerCharacter Read(int id)
        {
            return db.Characters.FirstOrDefault(player => player.Id == id);
        }
        public IQueryable<PlayerCharacter> ReadAll()
        {
            return db.Characters;
        }
        public void Update(PlayerCharacter character)
        {
            var x = Read(character.Id);
            x.Name = character.Name;
            x.RaceId = character.RaceId;
            x.ClassId = character.ClassId;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
