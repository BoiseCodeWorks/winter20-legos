using System;
using System.Collections.Generic;
using winter20_legos.Models;
using winter20_legos.Repositories;

namespace winter20_legos.Services
{
  public class KitsService
  {
    private readonly KitsRepository _repo;

    public KitsService(KitsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Kit> Get()
    {
      return _repo.Get();
    }
    internal Kit Get(int id)
    {
      Kit exists = _repo.Get(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    internal Kit Create(Kit newKit)
    {
      int id = _repo.Create(newKit);
      newKit.Id = id;
      return newKit;
    }

    internal string Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}