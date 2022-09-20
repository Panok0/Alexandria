namespace Mpanagos.Alexandria.Data.Joins;

using Mpanagos.Alexandria.Data.Model;

public class BookAuthor
{
  public Book Book { get; set; } = default!;

  public Author Author { get; set; } = default!;
}
