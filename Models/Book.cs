using System;

namespace library_web.Models
{
  public class Book
  {
    public Book()
    {
      id = Guid.NewGuid().ToString();

    }

    public Book(string title, string author, int pageCount)
    {
      Title = title;
      Author = author;
      PageCount = pageCount;
      id = Guid.NewGuid().ToString();
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public string id { get; set; }
    public bool IsAvalible { get; set; } = true;
  }
}