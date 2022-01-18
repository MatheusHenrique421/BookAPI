using Microsoft.EntityFrameworkCore;

namespace BookAPI.Model
{
  public class BookContext : DbContext
  {
    //A cada nova entidade, cria um DbSet com a Tabelas relativa.
    public DbSet<Book> Book { set; get; }
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    Database.EnsureCreatedAsync();
    }

    
    
  }
}
