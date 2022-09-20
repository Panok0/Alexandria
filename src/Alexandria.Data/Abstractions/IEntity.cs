#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable CA1040 // Avoid empty interfaces
namespace Mpanagos.Alexandria.Data.Abstractions;

public interface IEntity
{
}

public interface IEntity<TKey> : IEntity
  where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
  TKey Id { get; set; }
}
