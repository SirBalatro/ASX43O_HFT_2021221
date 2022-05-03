using ASX43O_HFT_2021221.Endpoint.Services;
using ASX43O_HFT_2021221.Logic;
using ASX43O_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public PlayerRaceController(IPlayerRaceLogic logic, IHubContext<SignalRHub> hub)
        {
            this.l = logic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("RaceCreated", value);
        }

        // PUT api/<PlayerRaceController>/5
        [HttpPut]
        public void Put([FromBody] PlayerRace value)
        {
            l.Update(value);
            hub.Clients.All.SendAsync("RaceUpdated", value);
        }

        // DELETE api/<PlayerRaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDelete = l.GetOne(id);
            l.Delete(id);
            hub.Clients.All.SendAsync("ClassDeleted", toDelete);
        }
    }
}
