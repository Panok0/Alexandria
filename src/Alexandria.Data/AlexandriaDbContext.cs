#nullable disable
namespace Mpanagos.Alexandria.Data;

using Microsoft.EntityFrameworkCore;

using Mpanagos.Alexandria.Data.Abstractions;
using Mpanagos.Alexandria.Data.Joins;
using Mpanagos.Alexandria.Data.Model;

public class AlexandriaDbContext : DbContext
{
  public AlexandriaDbContext(DbContextOptions<AlexandriaDbContext> options)
    : base(options)
  {
  }

  public DbSet<Book> Books { get; set; }

  public DbSet<Author> Authors { get; set; }

  public DbSet<Series> Series { get; set; }

  public DbSet<Category> Categories { get; set; }

  public DbSet<Publisher> Publishers { get; set; }

  public DbSet<BookAuthor> BookAuthors { get; set; }

  public DbSet<BookCategory> BookCategories { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ArgumentNullException.ThrowIfNull(modelBuilder);

    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<BookAuthor>(entity =>
    {
      entity.HasOne(e => e.Book)
      .WithMany()
      .HasForeignKey("BookId");

      entity.HasOne(e => e.Author)
      .WithMany()
      .HasForeignKey("AuthorId");

      entity.HasKey("BookId", "AuthorId");
    });

    modelBuilder.Entity<BookCategory>(entity =>
    {
      entity.HasOne(e => e.Book)
      .WithMany()
      .HasForeignKey("BookId");

      entity.HasOne(e => e.Category)
      .WithMany()
      .HasForeignKey("CategoryId");

      entity.HasKey("BookId", "CategoryId");
    });
  }
}
