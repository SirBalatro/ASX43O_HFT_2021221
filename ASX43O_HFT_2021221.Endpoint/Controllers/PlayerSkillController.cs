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
    public class PlayerSkillController : ControllerBase
    {
        IPlayerSkillLogic logic;
        public PlayerSkillController(IPlayerSkillLogic logic)
        {
            this.logic = logic;
        }


        // GET: api/<PlayerSkillController>
        [HttpGet]
        public IEnumerable<PlayerSkill> Get()
        {
            return logic.GetAll();
        }

        // GET api/<PlayerSkillController>/5
        [HttpGet("{id}")]
        public PlayerSkill Get(int id)
        {
            return logic.GetOne(id);
        }

        // POST api/<PlayerSkillController>
        [HttpPost]
        public void Post([FromBody] PlayerSkill value)
        {
            logic.Create(value);
        }

        // PUT api/<PlayerSkillController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] PlayerSkill value)
        {
            logic.Update(value);
        }

        // DELETE api/<PlayerSkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
