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
  public class KitsController : ControllerBase
  {


    private readonly KitsService _ks;
    private readonly BricksService _bs;

    public KitsController(KitsService ks, BricksService bs)
    {
      _ks = ks;
      _bs = bs;
    }

    // GET api/kits
    [HttpGet]
    public ActionResult<IEnumerable<Kit>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/kits/5
    [HttpGet("{id}")]
    public ActionResult<Kit> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/kits
    [HttpPost]
    public ActionResult<Kit> Post([FromBody] Kit newKit)
    {
      try
      {
        return Ok(_ks.Create(newKit));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/kits/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{kitId}/kitbricks")]
    public ActionResult<IEnumerable<Brick>> GetKitBricks(int kitId)
    {
      try
      {
        return Ok(_bs.GetBricksByKitId(kitId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}

