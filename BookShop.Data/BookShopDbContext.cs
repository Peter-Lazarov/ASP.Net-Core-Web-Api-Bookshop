namespace BookShop.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> CategoryBooks { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Author>()
                .HasMany(a => a.AllBooks)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            builder
                .Entity<Book>()
                .HasMany(b => b.Categories)
                .WithOne(cb => cb.Book)
                .HasForeignKey(b => b.BookId);

            builder
                .Entity<BookCategory>()
                .HasKey(bc => new { bc.CategoryId, bc.BookId });
        }
        
        //up to 22:05
       
    }
}
