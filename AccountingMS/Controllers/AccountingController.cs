using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        // GET: api/<AccountingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Accountin1", "Acc2" };
        }

        // GET api/<AccountingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
