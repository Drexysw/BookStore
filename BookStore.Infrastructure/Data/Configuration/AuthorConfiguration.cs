using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineBookstoreManagementSystem.Infrastructure.Data.SeedDb
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
           
            var data = new SeedData();
            builder.HasData(new Author[] { data.FirstAuthor, data.SecondAuthor, data.ThirdAuthor });
        }
    }
}
