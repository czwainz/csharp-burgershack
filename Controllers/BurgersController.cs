using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : ControllerBase
  {

    public List<Burger> Burgers = new List<Burger>()
    {
      new Burger("Chrissy", "Turkey Burger", 5.99f),
      new Burger("Different", "Vegetarian", 8.54f),
      new Burger("Another", "Another vegetarian", 5.55f)

  };


    // GET api/Burgers
    [HttpGet]
    public IEnumerable<Burger> Get()
    {
      return Burgers;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      try
      {
        return Burgers[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound();
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<List<Burger>> Post([FromBody] Burger burger)
    {
      Burgers.Add(burger);
      return Burgers;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
