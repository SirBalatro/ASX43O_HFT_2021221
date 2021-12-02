using ASX43O_HFT_2021221.Logic;
using ASX43O_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASX43O_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerRaceController : ControllerBase
    {
        IPlayerRaceLogic l;
        public PlayerRaceController(IPlayerRaceLogic logic)
        {
            this.l = logic;
        }
        // GET: api/<PlayerRaceController>
        [HttpGet]
        public IEnumerable<PlayerRace> Get()
        {
            return l.GetAll();
        }

        // GET api/<PlayerRaceController>/5
        [HttpGet("{id}")]
        public PlayerRace Get(int id)
        {
            return l.GetOne(id);
        }

        // POST api/<PlayerRaceController>
        [HttpPost]
        public void Post([FromBody] PlayerRace value)
        {
            l.Create(value);
        }

        // PUT api/<PlayerRaceController>/5
        [HttpPut]
        public void Put([FromBody] PlayerRace value)
        {
            l.Update(value);
        }

        // DELETE api/<PlayerRaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            l.Delete(id);
        }
    }
}
