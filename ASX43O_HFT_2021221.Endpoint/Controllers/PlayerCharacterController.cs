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
    public class PlayerCharacterController : ControllerBase
    {
        IPlayerCharacterLogic l;
        IHubContext<SignalRHub> hub;

        public PlayerCharacterController(IPlayerCharacterLogic logic, IHubContext<SignalRHub> hub)
        {
            this.l = logic;
            this.hub = hub;
        }
        // GET: api/<PlayerCharacterController>
        [HttpGet]
        public IEnumerable<PlayerCharacter> Get()
        {
            return l.GetAll();
        }

        // GET api/<PlayerCharacterController>/5
        [HttpGet("{id}")]
        public PlayerCharacter Get(int id)
        {
            return l.GetOne(id);
        }

        // POST api/<PlayerCharacterController>
        [HttpPost]
        public void Post([FromBody] PlayerCharacter value)
        {
            l.Create(value);
            hub.Clients.All.SendAsync("CharacterCreated", value);
        }

        // PUT api/<PlayerCharacterController>/5
        [HttpPut]
        public void Put([FromBody] PlayerCharacter value)
        {
            l.Update(value);
            hub.Clients.All.SendAsync("CharacterUpdated", value);
        }

        [HttpPut("{id}")]
        public void LevelUp(int id)
        {
            l.LevelUp(id);
        }

        // DELETE api/<PlayerCharacterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDelete = l.GetOne(id);
            l.Delete(id);
            hub.Clients.All.SendAsync("CharacterDeleted", toDelete);
        }
    }
}
