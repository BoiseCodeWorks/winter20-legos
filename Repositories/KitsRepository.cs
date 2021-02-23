using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using winter20_legos.Models;
namespace winter20_legos.Repositories
{
  public class KitsRepository
  {
    private readonly IDbConnection _db;

    public KitsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Kit> Get()
    {
      string sql = "SELECT * FROM kits;";
      return _db.Query<Kit>(sql);
    }

    internal Kit Get(int id)
    {
      string sql = "SELECT * FROM kits WHERE id = @id;";
      return _db.QueryFirstOrDefault<Kit>(sql, new { id });
    }

    internal int Create(Kit newKit)
    {
      string sql = @"
      INSERT INTO kits
      (name, instructions, price)
      VALUES
      (@Name, @Instructions, @Price);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKit);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM kits WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}