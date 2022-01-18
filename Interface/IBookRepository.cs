using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Model;

namespace BookAPI.Repository
{
  public interface IBookRepository
  {
    Task<IEnumerable<Book>> GetAll();
    Task<Book> Get(long Id);
    Task<Book> Create(Book book);
    Task Update(Book book);
    Task Delete(long Id);
  }
}
