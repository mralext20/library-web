using System;
using System.Collections.Generic;
using library_web.Models;
using library_web.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_web.Controllers
{


  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private BooksService _bs { get; set; }
    public BooksController(BooksService bs)
    {
      _bs = bs;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {

      try
      {
        Book book = _bs.Get(id);
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
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
      try
      {
        Book book = _bs.create(newBook);
        return Created($"/api/books/{book.id}", book);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
        throw;
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
