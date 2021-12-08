﻿using System;
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

        public void Delete(int id)
        {
            charRepo.Delete(id);
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
            charRepo.LevelUp(id);
        }

        public void Update(PlayerCharacter entity)
        {
            charRepo.Update(entity);
        }

        public IEnumerable<AverageResult> RaceLevelAverage()
        {
            var q = from c in charRepo.GetAll()
                    group c by new { c.RaceId, c.Race.Name } into g
                    select new AverageResult(g.Key.Name, g.Average(x => x.CharacterLevel));
            return q.ToList();
        }

        public double LevelAverage()
        {
            return (double)charRepo.GetAll().Average(x => x.CharacterLevel);
        }
    }
}
