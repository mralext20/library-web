using System;
using System.Collections.Generic;
using library_web.Models;
using library_web.Services;
using Microsoft.AspNetCore.Mvc;

namespace library_web.Controllers
{


  [ApiController]
  [Route("api/[controller]")]
  public class LibrarysController : ControllerBase
  {
    private LibrarysService _ls { get; set; }
    public LibrarysController(LibrarysService ls)
    {
      _ls = ls;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Library>> Get()
    {
      try
      {
        return Ok(_ls.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Library> GetById(int id)
    {

      try
      {
        Library Library = _ls.Get(id);
        return Ok(Library);
      }
      catch (ArgumentNullException)
      {
        return BadRequest("could not find that Library");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Library> Create([FromBody] Library newLibrary)
    {
      try
      {
        Library Library = _ls.create(newLibrary);
        return Created($"/api/Librarys/{Library.id}", Library);
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
        return Ok(_ls.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
