using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using winter20_legos.Models;
using winter20_legos.Services;
using Microsoft.AspNetCore.Mvc;

namespace winter20_legos.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BricksController : ControllerBase
  {
    private readonly BricksService _bs;

    public BricksController(BricksService bs)
    {
      _bs = bs;
    }

    // GET api/bricks
    [HttpGet]
    public ActionResult<IEnumerable<Brick>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/bricks/5
    [HttpGet("{id}")]
    public ActionResult<Brick> Get(int id)
    {
      try
      {
        return Ok(_bs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/bricks
    [HttpPost]
    public ActionResult<Brick> Post([FromBody] Brick newBrick)
    {
      try
      {
        return Ok(_bs.Create(newBrick));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/bricks/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

