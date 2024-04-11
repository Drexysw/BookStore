using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(o => new { o.BuyerId, o.BookId });

            builder.Entity<Order>()
                .HasOne(o => o.Book)
                .WithMany(o => o.Orders)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
        }
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
    }
}
