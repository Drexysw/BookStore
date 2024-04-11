using BookStore.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookStore.Infrastructure.Data.Models;

namespace BookStore.Infrastructure.Data.SeedDb
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);
            var data = new SeedData();
            builder.HasData(new ApplicationUser[] {data.AdminUser, data.GuestUser });
        }
    }
}
