using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data.Models;
using BookStore.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        private bool _seedDb;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool seed = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }
            _seedDb = seed;

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (_seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new BookConfiguration());
                builder.ApplyConfiguration(new CategoryConfiguration());
                builder.ApplyConfiguration(new AuthorConfiguration());
                builder.ApplyConfiguration(new SellerConfiguration());
                builder.ApplyConfiguration(new OrderConfiguration());
            }
            else
            {
                builder.Entity<Order>()
               .HasKey(o => new { o.BuyerId, o.BookId });

                builder.Entity<Order>()
                    .HasOne(o => o.Book)
                    .WithMany(o => o.Orders)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.Entity<Book>()
                 .HasOne(h => h.Category)
                 .WithMany(c => c.Books)
                 .HasForeignKey(h => h.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Book>()
                    .HasOne(h => h.Seller)
                    .WithMany(a => a.Books)
                    .HasForeignKey(h => h.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Book>()
                    .HasOne(b => b.Author)
                    .WithMany(c => c.Books)
                    .HasForeignKey(h => h.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
            base.OnModelCreating(builder);
        }
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
    }
}
