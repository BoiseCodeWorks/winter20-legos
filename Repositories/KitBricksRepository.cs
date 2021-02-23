using System;
using System.Data;
using Dapper;
using winter20_legos.Models;

namespace winter20_legos.Repositories
{
  public class KitBricksRepository
  {
    private readonly IDbConnection _db;

    public KitBricksRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(KitBrick newKb)
    {
      string sql = @"
        INSERT INTO kitbricks
        (kitId, brickId)
        VALUES
        (@KitId, @BrickId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKb);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM kitbricks WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}