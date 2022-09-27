namespace Mpanagos.Alexandria.Data.Model;

using Mpanagos.Alexandria.Data.Base;

public class Book : Entity<long>
{
  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public Publisher Publisher { get; set; } = default!;

  public Series? Series { get; set; }

  public int? SeriesIndex { get; set; }

  public string Category { get; set; } = string.Empty;

  public DateTimeOffset PublishedAt { get; set; }
}
