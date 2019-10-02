using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWorm8.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AuthorBook>()
                .HasKey(m2m => new { m2m.AuthorId, m2m.BookId });

            builder.Entity<AuthorBook>()
                .HasOne(m2m => m2m.Author)
                .WithMany(o => o.Books)
                .HasForeignKey(m2m => m2m.AuthorId);

            builder.Entity<AuthorBook>()
                .HasOne(m2m => m2m.Book)
                .WithMany(o => o.Authors)
                .HasForeignKey(m2m => m2m.BookId);

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
    }
}
