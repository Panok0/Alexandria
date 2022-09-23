namespace Mpanagos.Alexandria.Data.Model;

using Mpanagos.Alexandria.Data.Base;

public class Book : Entity<long>
{
  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public string Publisher { get; set; } = string.Empty;

  public string Series { get; set; } = string.Empty;

  public string Category { get; set; } = string.Empty;

}
