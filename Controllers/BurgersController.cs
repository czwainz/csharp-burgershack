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
  public class BurgersController : ControllerBase
  {
    private readonly BurgerRepository _burgerRepo;
    public BurgersController(BurgerRepository burgerRepo)
    {
      _burgerRepo = burgerRepo;
    }


    // GET api/Burgers
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      return Ok(_burgerRepo.GetAllBurgers());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      Burger result = _burgerRepo.GetBurgerByID(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();

    }

    // POST api/values
    [HttpPost]
    public ActionResult<List<Burger>> Post([FromBody] Burger burger)
    {
      return Created("/api/burgers/", _burgerRepo.AddBurger(burger));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Burger> Put(int id, [FromBody] Burger burger)
    {
      Burger result = _burgerRepo.EditBurger(id, burger);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_burgerRepo.DeleteBurger(id))
      {
        return Ok("Success");
      }
      return NotFound("No burger to delete");
    }
  }
}
