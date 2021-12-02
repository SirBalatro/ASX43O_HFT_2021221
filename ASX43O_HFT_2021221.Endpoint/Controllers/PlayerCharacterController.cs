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
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerCharacterController : ControllerBase
    {
        IPlayerCharacterLogic l;
        public PlayerCharacterController(IPlayerCharacterLogic logic)
        {
            this.l = logic;
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
        }

        // PUT api/<PlayerCharacterController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] PlayerCharacter value)
        {
            l.Update(value);
        }

        // DELETE api/<PlayerCharacterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            l.Delete(id);
        }
    }
}
