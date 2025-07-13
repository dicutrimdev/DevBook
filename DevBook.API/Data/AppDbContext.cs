using DevBook.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevBook.API.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Author { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(author => author.AuthorId);
    }
}
