namespace Mpanagos.Alexandria.Web.Server.Controller;

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
}
