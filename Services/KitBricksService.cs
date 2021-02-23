using System;
using winter20_legos.Models;
using winter20_legos.Repositories;

namespace winter20_legos.Services
{
  public class KitBricksService
  {
    private readonly KitBricksRepository _repo;

    public KitBricksService(KitBricksRepository repo)
    {
      _repo = repo;
    }

    public KitBrick Create(KitBrick newKb)
    {
      int id = _repo.Create(newKb);
      newKb.Id = id;
      return newKb;
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}