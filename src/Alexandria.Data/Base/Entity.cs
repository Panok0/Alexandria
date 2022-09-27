#nullable disable
namespace Mpanagos.Alexandria.Data.Base;

using Mpanagos.Alexandria.Data.Abstractions;

public abstract class Entity<TKey> : IEntity<TKey>
  where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
  public TKey Id { get; set; }
}
