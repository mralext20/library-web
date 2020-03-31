using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using library_web.Models;

namespace library_web.Repositories
{
  public class BookRepo
  {
    private readonly IDbConnection _db;
    public BookRepo(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Book> Get()
    {
      string sql = "SELECT * FROM books";
      return _db.Query<Book>(sql);
    }

    internal Book Get(int id)
    {
      string sql = "SELECT * FROM books WHERE id = @id";
      return _db.QueryFirstOrDefault<Book>(sql);
    }


    internal Book Create(Book newBook)
    {
      string sql = @"
      INSERT INTO books (
        
      ) VALUES (

      ); 
      SELECT LAST_INSERT_ID();";
      newBook.id = _db.ExecuteScalar<int>(sql, newBook);
      return newBook;
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM books WHERE ID = @id LIMIT 1";
      return _db.Execute(sql, new { id }) == 1;
    }
  }
}