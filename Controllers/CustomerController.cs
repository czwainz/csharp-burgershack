using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    private readonly CustomerRepository _customerRepo;
    public CustomerController(CustomerRepository customerRepo)
    {
      _customerRepo = customerRepo;
    }
    // GET api/values
    // [HttpGet]
    // public ActionResult<IEnumerable<string>> Get()
    // {
    //   return new string[] { "value1", "value2" };
    // }

    // GET api/values/5
    // [HttpGet("{id}")]
    // public ActionResult<string> Get(int id)
    // {
    //   return "value";
    // }

    // POST api/values
    [HttpPost]
    public ActionResult<Customer> Post([FromBody] Customer customer)
    {
      Customer result = _customerRepo.AddCustomer(customer);
      return Created("/api/customer/" + result.Id, result);
    }

    // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_customerRepo.DeleteCustomer(id))
      {
        return Ok("Success!!!");
      }
      return NotFound("No customer to delete");
    }


  }
}
