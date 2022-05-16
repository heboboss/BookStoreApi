using Microsoft.EntityFrameworkCore;

namespace BooksSoreApp.Entities
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<AuthorEntity> Authors { get; set; }
        DbSet<BookEntity> Books { get; set; }
    }
}
