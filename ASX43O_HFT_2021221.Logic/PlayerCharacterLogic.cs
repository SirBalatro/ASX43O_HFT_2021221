using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASX43O_HFT_2021221.Models;
using ASX43O_HFT_2021221.Repository;

namespace ASX43O_HFT_2021221.Logic
{
    public class PlayerCharacterLogic : IPlayerCharacterLogic
    {
        ICharacterRepository charRepo;

        public PlayerCharacterLogic(ICharacterRepository charRepo)
        {
            this.charRepo = charRepo;
        }

        public void ChangeName(int id, string name)
        {
            charRepo.ChangeName(id, name);
        }

        public void Create(PlayerCharacter entity)
        {
            if (entity.CharacterLevel < 0)
            {
                throw new ArgumentException(nameof(entity), "Character level can't be negative");
            }
            charRepo.Create(entity);
        }

        public void Delete(PlayerCharacter entity)
        {
            charRepo.Delete(entity);
        }

        public IQueryable<PlayerCharacter> GetAll()
        {
            return charRepo.GetAll();
        }

        public PlayerCharacter GetOne(int id)
        {
            return charRepo.GetOne(id);
        }

        public void LevelUp(int id)
        {
            charRepo.LevelUp(id);
        }
    }
}
