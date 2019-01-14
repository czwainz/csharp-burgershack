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
  public class DrinksController : ControllerBase
  {
    public List<Drink> Drinks = new List<Drink>()
    {
      new Drink("Cola", "Literacola", 3f),
      new Drink("Sprite", "A clear choice", 4f),
      new Drink("Ginger Ale", "For your tum tum", 4)
  };

    [HttpGet]
    public IEnumerable<Drink> Get()
    {
      return Drinks;
    }

    [HttpGet("{id}")]
    public ActionResult<Drink> Get(int id)
    {
      try
      {
        return Drinks[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"No such drink!\"}");
      }
    }

    [HttpPost]
    public IEnumerable<Drink> Post([FromBody] Drink drink)
    {
      Drinks.Add(drink);
      return Drinks;
    }

    [HttpPut("{id}")]
    public ActionResult<List<Drink>> Put(int id, [FromBody] Drink drink)
    {
      try
      {
        Drinks[id] = drink;
        return Drinks;

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"No such drink!\"}");
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<List<Drink>> Delete(int id)
    {
      try
      {
        Drinks.Remove(Drinks[id]);
        return Drinks;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"No such drink!\"}");
      }
    }

  }
}