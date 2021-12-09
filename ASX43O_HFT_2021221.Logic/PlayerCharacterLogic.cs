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
        private ICharacterRepository charRepo;

        public PlayerCharacterLogic(ICharacterRepository charRepo)
        {
            this.charRepo = charRepo;
        }

        public void Create(PlayerCharacter entity)
        {
            if (entity.Name != null && entity.Name != "" && entity.CharacterLevel >= 0)
            {
                charRepo.Create(entity);
            }
            else
            {
                throw new ArgumentException("Character creation failed, name or level invalid");
            }
        }

        public void Delete(PlayerCharacter entity)
        {
            if (charRepo.GetAll().Contains(entity))
            {
                charRepo.Delete(entity);
            }
            else
            {
                throw new Exception("Given character doesn't exist");
            }
        }

        public void Delete(int id)
        {
            if (charRepo.GetAll().Any(x => x.Id.Equals(id)))
            {
                charRepo.Delete(id);
            }
            else
            {
                throw new Exception("Given character id doesn't exist");
            }
        }

        public IEnumerable<PlayerCharacter> GetAll()
        {
            return charRepo.GetAll();
        }

        public PlayerCharacter GetOne(int id)
        {
            return charRepo.GetOne(id);
        }

        public void LevelUp(int id)
        {
            if (charRepo.GetAll().Any(x => x.Id.Equals(id)))
            {
                charRepo.LevelUp(id);
            }
            else
            {
                throw new Exception("Given character id doesn't exist");
            }
        }

        public void Update(PlayerCharacter entity)
        {
            if (entity.Id > 0 && entity.Name != null && entity.Name != "" && entity.CharacterLevel >= 0)
            {
                charRepo.Update(entity);
            }
            else
            {
                throw new ArgumentException("Character update failed, id, name or level invalid");
            }
        }

        public double LevelAverage()
        {
            return (double)charRepo.GetAll().Average(x => x.CharacterLevel);
        }
    }
}
