using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookAPI.Repository;
using BookAPI.Model;

namespace BookAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookController : ControllerBase
  {
    private readonly IBookRepository _bookRepository;
    public BookController(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetAll()
    {
      return await _bookRepository.GetAll();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Book>> GetById(long Id)
    {
      return await _bookRepository.Get(Id);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> Create([FromBody] Book book)
    {
      var newBook = await _bookRepository.Create(book);
      return CreatedAtAction(nameof(GetById), new { Id = newBook.Id }, newBook);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete(long Id)
    {
      var bookDelete = await _bookRepository.Get(Id);

      if (bookDelete == null)
        return NotFound();

      await _bookRepository.Delete(bookDelete.Id);

      return NoContent();
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> Put(long Id, [FromBody] Book book)
    {
      if (Id != book.Id)
        return BadRequest();

      await _bookRepository.Update(book);

      return NoContent();
    }

  }
}
