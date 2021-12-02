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
    public class PlayerItemController : ControllerBase
    {
        IPlayerItemLogic l;
        public PlayerItemController(IPlayerItemLogic logic)
        {
            this.l = logic;
        }
        // GET: api/<PlayerItemController>
        [HttpGet]
        public IEnumerable<PlayerItem> Get()
        {
            return l.GetAll();
        }

        // GET api/<PlayerItemController>/5
        [HttpGet("{id}")]
        public PlayerItem Get(int id)
        {
            return l.GetOne(id);
        }

        // POST api/<PlayerItemController>
        [HttpPost]
        public void Post([FromBody] PlayerItem value)
        {
            l.Create(value);
        }

        // PUT api/<PlayerItemController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] PlayerItem value)
        {
            l.Update(value);
        }

        // DELETE api/<PlayerItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            l.Delete(id);
        }
    }
}
