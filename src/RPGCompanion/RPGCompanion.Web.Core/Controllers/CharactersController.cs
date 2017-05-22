using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RPGCompanion.Domain.Abstract;

namespace RPGCompanion.Web.Core.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return new List<Character>
            {
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Character Get(Guid id)
        {
            return new Character(new List<Trait>())
            {
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Character value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Character value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
