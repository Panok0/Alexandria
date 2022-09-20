#nullable disable
namespace Mpanagos.Alexandria.Data;

using Microsoft.EntityFrameworkCore;

using Mpanagos.Alexandria.Data.Abstractions;
using Mpanagos.Alexandria.Data.Joins;
using Mpanagos.Alexandria.Data.Model;

public class AlexandriaDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  public DbSet<Author> Authors { get; set; }

  public DbSet<BookAuthor> BookAuthors { get; set; }
}
