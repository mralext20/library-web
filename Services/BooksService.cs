using System;
using System.Collections.Generic;
using library_web.Models;
using library_web.Repositories;

namespace library_web.Services
{
  public class BooksService
  {
    private BookRepo _repo { get; set; }
    public BooksService(BookRepo repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Book> Get()
    {
      return _repo.Get();
    }

    internal Book Get(int id)
    {
      return _repo.Get(id);
    }

    internal Book create(Book newBook)
    {
      return _repo.Create(newBook);
    }
    internal bool Delete(int id)
    {
      return _repo.Delete(id);
    }
  }
}