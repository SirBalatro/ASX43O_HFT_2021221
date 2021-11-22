﻿using ASX43O_HFT_2021221.Models;
using ASX43O_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Logic
{
    public class PlayerRaceLogic : IPlayerRaceLogic
    {
        IRaceRepository raceRepo;

        public PlayerRaceLogic(IRaceRepository raceRepo)
        {
            this.raceRepo = raceRepo;
        }
        public void ChangeName(int id, string name)
        {
            raceRepo.ChangeName(id, name);
        }

        public void Create(PlayerRace entity)
        {
            raceRepo.Create(entity);
        }

        public void Delete(PlayerRace entity)
        {
            raceRepo.Delete(entity);
        }

        public IQueryable<PlayerRace> GetAll()
        {
            return raceRepo.GetAll();
        }

        public PlayerRace GetOne(int id)
        {
            return raceRepo.GetOne(id);
        }
    }
}
