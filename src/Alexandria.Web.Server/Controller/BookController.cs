namespace Mpanagos.Alexandria.Web.Server.Controller;

using System.Runtime.InteropServices;

using Microsoft.AspNetCore.Mvc;

using Mpanagos.Alexandria.Data;
using Mpanagos.Alexandria.Data.Model;

[Route("/api/book")]
public class BookController
{
  private readonly AlexandriaDbContext ctx;

  public BookController(AlexandriaDbContext ctx)
  {
    this.ctx = ctx;
  }

  [HttpGet("")]
  public List<Book> GetBooks()
  {
    return ctx.Books.ToList();
  }

  [HttpGet("{id}")]
  public Book GetBook(long id)
  {
    return ctx.Books.FirstOrDefault(x => x.Id == id);
  }

  [HttpPost("")]
  public Book CreateBook(Book book)
  {
    var b = new Book
    {
      Description = book.Description,
      Title = book.Title,
    };
    ctx.Books.Add(b);
    ctx.SaveChanges();

    return b;
  }

  [HttpPut("{id}")]
  public Book UpdateBook(long id, Book book)
  {
    var b = ctx.Books.FirstOrDefault(x => x.Id == id);
    if (b == null)
    {
      return null;
    }

    b.Description = book.Description;
    b.Title = book.Title;

    ctx.SaveChanges();

    return b;
  }

  [HttpDelete("{id}")]
  public void DeleteBook(long id)
  {
    var b = ctx.Books.FirstOrDefault(x => x.Id == id);
    if (b == null)
    {
      return;
    }

    ctx.Books.Remove(b);
    ctx.SaveChanges();
  }
}
