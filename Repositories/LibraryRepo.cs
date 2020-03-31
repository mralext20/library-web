using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using library_web.Models;

namespace library_web.Repositories
{
  public class LibraryRepo
  {
    private readonly IDbConnection _db;
    public LibraryRepo(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Library> Get()
    {
      string sql = "SELECT * FROM libraries";
      return _db.Query<Library>(sql);
    }

    internal Library Get(int id)
    {
      string sql = "SELECT * FROM libraries WHERE id = @id";
      return _db.QueryFirstOrDefault<Library>(sql, new { id });
    }


    internal Library Create(Library newLibrary)
    {
      string sql = @"
      INSERT INTO libraries (
        
      ) VALUES (

      ); 
      SELECT LAST_INSERT_ID();";
      newLibrary.id = _db.ExecuteScalar<int>(sql, newLibrary);
      return newLibrary;
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM libraries WHERE ID = @id LIMIT 1";
      return _db.Execute(sql, new { id }) == 1;
    }
  }
}