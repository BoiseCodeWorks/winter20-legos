using System;
using Microsoft.AspNetCore.Mvc;
using winter20_legos.Models;
using winter20_legos.Services;

namespace winter20_legos.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KitBricksController : ControllerBase
  {
    private readonly KitBricksService _service;

    public KitBricksController(KitBricksService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<KitBrick> Post([FromBody] KitBrick newKb)
    {
      try
      {
        return Ok(_service.Create(newKb));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}