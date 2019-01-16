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
  public class SidesController : ControllerBase
  {
    private readonly SideRepository _sideRepo;
    public SidesController(SideRepository sideRepo)
    {
      _sideRepo = sideRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      return Ok(_sideRepo.GetAllSides());
    }

    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      Side result = _sideRepo.GetSidesByID(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();

    }


    [HttpPost]
    public ActionResult<List<Side>> Post([FromBody] Side side)
    {
      Side result = _sideRepo.AddSide(side);
      return Created("/api/sides/" + result.Id, result);
    }

    [HttpPut("{id}")]
    public ActionResult<Side> Put(int id, [FromBody] Side side)
    {
      Side result = _sideRepo.EditSide(id, side);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_sideRepo.DeleteSide(id))
      {
        return Ok("Success");
      }
      return NotFound("No side to delete");
    }

  }
}