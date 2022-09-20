namespace Mpanagos.Alexandria.Data.Model;

using Mpanagos.Alexandria.Data.Base;
using Mpanagos.Alexandria.Data.Joins;

public class Author : Entity<long>
{
  public string Name { get; set; } = string.Empty;
}
