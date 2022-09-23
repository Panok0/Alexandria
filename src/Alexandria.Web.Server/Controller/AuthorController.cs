namespace Mpanagos.Alexandria.Web.Server.Controller;

using System.Runtime.InteropServices;

using Microsoft.AspNetCore.Mvc;

using Mpanagos.Alexandria.Data;
using Mpanagos.Alexandria.Data.Model;

[Route("/api/author")]
public class AuthorController : Controller
{
  private readonly AlexandriaDbContext ctx;

  public AuthorController(AlexandriaDbContext ctx)
  {
    this.ctx = ctx;
  }

  [HttpGet("")]
    public List<Author> GetAuthor()
  {
    return ctx.Authors.ToList();
  }

  [HttpGet("{id}")]
  public Author GetAuthor(long id)
  {
    return ctx.Authors.FirstOrDefault(x => x.Id == id);
  }

  [HttpPost("")]
  public Author GetAuthor(Author author)
  {
    var a = new Author
    {
      Name = author.Name,
      Description = author.Description,
    };
    ctx.Authors.Add(a);
    ctx.SaveChanges();

    return a;
  }

  [HttpPut("{id}")]
  public Author UpdateAuthor(long id, Author author)
  {
    var a = ctx.Authors.FirstOrDefault(x => x.Id == id);
    if (a == null)
    {
      return null;
    }

    a.Description = author.Description;
    a.Name = author.Name;

    ctx.SaveChanges();

    return a;
  }

  [HttpDelete("{id}")]
  public void DeleteAuthor(long id)
  {
    var a = ctx.Authors.FirstOrDefault(x => x.Id == id);
    if (a == null)
    {
      return;
    }

    ctx.Authors.Remove(a);
    ctx.SaveChanges();
  }
}
