using System;
using System.Collections.Generic;
using System.Linq;
using library_web.db;
using library_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_web.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      try
      {
        return Ok(FakeDb.books);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Book> GetById(string id)
    {

      try
      {
        Book book = FakeDb.books.Find(b => b.id == id);
        if (book is null)
        {
          throw new ArgumentNullException(nameof(book));
        }
        return Ok(book);
      }
      catch (ArgumentNullException)
      {
        return BadRequest("could not find that book");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book book)
    {
      try
      {
        FakeDb.books.Add(book);
        return Created($"/api/books/{book.id}", book);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
        throw;
      }
    }

    [HttpPut("{bookId}/checkout")]
    public ActionResult<Book> Checkout(string bookId)
    {
      try
      {
        Book book = FakeDb.books.Find(b => b.id == bookId);
        if (book is null)
        {
          throw new ArgumentNullException(nameof(book));
        }
        if (!book.IsAvalible)
        {
          throw new Exception("Book Already Checked Out");
        }
        book.IsAvalible = false;
        return Ok(book);
      }
      catch (ArgumentNullException)
      {
        return BadRequest("book does not exist");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{bookId}/return")]
    public ActionResult<Book> Return(string bookId)
    {
      try
      {
        Book book = FakeDb.books.Find(b => b.id == bookId);
        if (book is null)
        {
          throw new ArgumentNullException(nameof(book));
        }
        if (book.IsAvalible)
        {
          throw new Exception("that book is not checked out, you cant return it!");
        }
        book.IsAvalible = true;
        return Ok(book);
      }
      catch (ArgumentNullException)
      {
        return BadRequest("That book does not exist");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);

      }
    }
  }
}
