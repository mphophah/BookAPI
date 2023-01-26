// DbContext for the database
using Microsoft.EntityFrameworkCore;

public class BooksDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public BooksDbContext(DbContextOptions<BooksDbContext> options)
        : base(options)
    {
    }

}