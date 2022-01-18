using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Model;

namespace BookAPI.Repository
{
  public class BookRepository : IBookRepository
  {
    #region Constructor 
    public readonly BookContext _bookContext;
    public BookRepository(BookContext bookContext)
    {
      _bookContext = bookContext;
    }
    #endregion
    public async Task<Book> Create(Book book)
    {
      _bookContext.Book.Add(book);
      await _bookContext.SaveChangesAsync();
      return book;
    }

    public async Task Delete(long Id)
    {
      var bookDelete = await _bookContext.Book.FindAsync(Id);
      _bookContext.Book.Remove(bookDelete);
      await _bookContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
      return await _bookContext.Book.ToListAsync();
    }

    public async Task<Book> Get(long Id)
    {
      return await _bookContext.Book.FindAsync(Id);
    }

    public async Task Update(Book book)
    {
      _bookContext.Entry(book).State = EntityState.Modified;
      await _bookContext.SaveChangesAsync();
    }
  }
}
