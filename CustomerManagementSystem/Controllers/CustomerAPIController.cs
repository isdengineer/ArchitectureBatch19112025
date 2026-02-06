using CustomerManagementSystem.Application;
using CustomerManagementSystem.DTO;
using CustomerManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        // GET: api/<CustomerAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerAPIController>
        [HttpPost]
        public void Post([FromBody] CustomerDTO value)
        {
            var create = new CreateCustomerCommand();
            create.Name = value.Name;
            create.Amount = Convert.ToDecimal(value.Amount);
            foreach (var item in value.Addresses)
            {
                create.Addresses.Add(new Address() { Street1 = item.Street1 });
            }
            var handler = new CreateCustomerHandler();
            handler.Handle(create);
        }

        // PUT api/<CustomerAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
