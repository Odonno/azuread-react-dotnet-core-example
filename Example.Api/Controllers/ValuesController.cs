using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> _values = new List<string> { "X", "Y" };

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _values;
        }

        // POST api/values/X
        [HttpPost("{value}")]
        public void Post(string value)
        {
            _values.Add(value);
        }

        // DELETE api/values/X
        [HttpDelete("{value}")]
        public void Delete(string value)
        {
            _values.Remove(value);
        }
    }
}
