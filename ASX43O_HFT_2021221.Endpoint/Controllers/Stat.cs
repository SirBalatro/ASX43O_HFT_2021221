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
        public Stat(IPlayerCharacterLogic charLogic, IPlayerRaceLogic raceLogic)
        {
            this.charLogic = charLogic;
            this.raceLogic = raceLogic;
        }

        [HttpGet]
        public IEnumerable<AverageResult> RaceLevelAverage()
        {
            return charLogic.RaceLevelAverage();
        }

        [HttpGet]
        public double CharacterLevelAverage()
        {
            return charLogic.LevelAverage();
        }


    }
}
