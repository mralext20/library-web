using System;
using System.Collections.Generic;
using library_web.Models;
using library_web.Repositories;

namespace library_web.Services
{
  public class LibrarysService
  {
    private LibraryRepo _repo { get; set; }
    public LibrarysService(LibraryRepo repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Library> Get()
    {
      return _repo.Get();
    }

    internal Library Get(int id)
    {
      return _repo.Get(id);
    }

    internal Library create(Library newLibrary)
    {
      return _repo.Create(newLibrary);
    }
    internal bool Delete(int id)
    {
      return _repo.Delete(id);
    }
  }
}