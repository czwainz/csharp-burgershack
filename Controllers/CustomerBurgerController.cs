

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
  public class CustomerBurgerController : ControllerBase
  {
    private readonly CustomerBurgerRepository _custBurgRepo;
    public CustomerBurgerController(CustomerBurgerRepository cbr)
    {
      _custBurgRepo = cbr;
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
    public ActionResult<string> Post([FromBody] CustomerBurger cb)
    {
      CustomerBurger result = _custBurgRepo.AddCustomerBurger(cb);
      return Created("/api/customerburger/" + result.Id, result);
    }

    // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public ActionResult<string> Delete(int id)
    // {
    //   if (_customerRepo.DeleteCustomer(id))
    //   {
    //     return Ok("Success");
    //   }
    //   return NotFound("No customer to delete");
    // }


  }
}
