using System;
using System.Collections.Generic;
using winter20_legos.Models;
using winter20_legos.Repositories;

namespace winter20_legos.Services
{
  public class BricksService
  {
    private readonly BricksRepository _repo;
    private readonly KitsRepository _krepo;

    public BricksService(BricksRepository repo, KitsRepository krepo)
    {
      _repo = repo;
      _krepo = krepo;
    }


    internal IEnumerable<Brick> Get()
    {
      return _repo.Get();
    }
    internal Brick Get(int id)
    {
      Brick exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    internal Brick Create(Brick newBrick)
    {
      int id = _repo.Create(newBrick);
      newBrick.Id = id;
      return newBrick;
    }


    internal string Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }



    internal IEnumerable<Brick> GetBricksByKitId(int kitId)
    {
      Kit exists = _krepo.Get(kitId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.GetBricksByKitId(kitId);
    }
  }
}