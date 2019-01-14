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
  public class SidesController : ControllerBase
  {
    public List<Side> Sides = new List<Side>()
    {
      new Side("Tater Tots", "Delicious and crispy", 3f),
      new Side("Shoe String Fries", "The best kind of fries", 4f),
      new Side("Truffle Fries", "Made with delicious truffle salt", 4)
  };

    [HttpGet]
    public IEnumerable<Side> Get()
    {
      return Sides;
    }

    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      try
      {
        return Sides[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound();
      }
    }


  }
}