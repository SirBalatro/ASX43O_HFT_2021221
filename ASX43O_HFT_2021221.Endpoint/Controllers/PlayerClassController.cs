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
    public class PlayerClassController : ControllerBase
    {
        IPlayerClassLogic logic;
        public PlayerClassController(IPlayerClassLogic logic)
        {
            this.logic = logic;
        }


        // GET: api/<PlayerClassController>
        [HttpGet]
        public IEnumerable<PlayerClass> Get()
        {
            return logic.GetAll();
        }

        // GET api/<PlayerClassController>/5
        [HttpGet("{id}")]
        public PlayerClass Get(int id)
        {
            return logic.GetOne(id);
        }

        // POST api/<PlayerClassController>
        [HttpPost]
        public void Post([FromBody] PlayerClass value)
        {
            logic.Create(value);
        }

        // PUT api/<PlayerClassController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] PlayerClass value)
        {
            logic.Update(value);
        }

        // DELETE api/<PlayerClassController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
