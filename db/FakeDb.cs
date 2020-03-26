using System.Collections.Generic;
using library_web.Models;

namespace library_web.db
{
  class FakeDb
  {
    public static List<Book> books = new List<Book>() {
      new Book("Things to do while quarentied", "mark ohnsman", 20_000),
      new Book("how to ride a bike", "someone not quarentined", 200)
    };
  }
}