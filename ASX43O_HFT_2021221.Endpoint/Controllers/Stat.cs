using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASX43O_HFT_2021221.Logic;
using ASX43O_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASX43O_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class Stat : ControllerBase
    {
        IPlayerCharacterLogic charLogic;
        IPlayerRaceLogic raceLogic;
        IPlayerClassLogic classLogic;
        IPlayerItemLogic itemLogic;
        INonCrudLogic ncLogic;
        public Stat(IPlayerCharacterLogic charLogic, IPlayerRaceLogic raceLogic, IPlayerClassLogic classLogic, IPlayerItemLogic itemLogic, INonCrudLogic nonCrudLogic)
        {
            this.charLogic = charLogic;
            this.raceLogic = raceLogic;
            this.classLogic = classLogic;
            this.itemLogic = itemLogic;
            this.ncLogic = nonCrudLogic;
        }

        [HttpGet]
        public double CharacterLevelAverage()
        {
            return charLogic.LevelAverage();
        }

        [HttpGet]
        public PlayerCharacter CharacterWithBestItem()
        {
            return ncLogic.CharacterWithBestItem();
        }

    }
}
