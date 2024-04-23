using BookStore.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BookStore.Infrastructure.Data.Configuration
{
    public class SeedDataBase
    {
        public static Seller AdminSeller { get; set; } = new Seller();
        public static ApplicationUser Admin2User { get; set; } = new ApplicationUser();
        public static ApplicationUser GuestUser { get; set; } = new ApplicationUser();
        public static Category ThrillerCategory { get; set; } = new Category();
        public static Book FirstBook { get; set; } = new Book();
        public static Author FirstAuthor { get; set; } = new Author();
        public static Order FirstOrder { get; set; } = new Order();
        public static void SeedDatabase(ApplicationDbContext book)
        {
            SeedUsers();
            SeedSellers();
            SeedCategories();
            SeedAuthors();
            SeedBooks();
            SeedOrders();

            book.Add(AdminSeller);
            book.Add(Admin2User);
            book.Add(GuestUser);
            book.Add(ThrillerCategory);
            book.Add(FirstBook);
            book.Add(FirstAuthor);
            book.Add(FirstOrder);
        }
        public static void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            Admin2User = new ApplicationUser()
            {
                Id = "bff69dcd-47cd-452a-8536-4823df1b2e70",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                SecurityStamp = "2e3112b8-6559-4e6f-a6ce-ee9595405798",
                FirstName = "Stamo",
                LastName = "Petkov"
            };
            Admin2User.PasswordHash = hasher.HashPassword(Admin2User, "admin2123");
            GuestUser = new ApplicationUser()
            {
                Id = "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                UserName = "guestuser@gmail.com",
                NormalizedUserName = "guestuser@gmail.com",
                Email = "guestuser@gmail.com",
                NormalizedEmail = "guestuser@gmail.com",
                SecurityStamp = "9d7490d5-eff5-4123-994a-2e5a2f8b9a8c",
                FirstName = "David",
                LastName = "Davidov"
            };
            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");

        }
        private static void SeedSellers()
        {
            AdminSeller = new Seller()
            {
                Id = 2,
                Name = "Stamo",
                Rating = 6,
                PhoneNumber = "+0875423556",
                UserId = Admin2User.Id,
            };
        }
        private static void SeedCategories()
        {
            ThrillerCategory = new Category()
            {
                Id = 1,
                Name = "Thriller"
            };
            
        }

        private static void SeedBooks()
        {
            FirstBook = new Book()
            {
                Id = 1,
                Title = "The silent patient",
                Description = "This is a third series book in the author collection.It represents the author inimaginary situation in the past",
                CategoryId = ThrillerCategory.Id,
                AuthorId = FirstAuthor.Id,
                Price = 40.00m,
                ImageUrl = "https://m.media-amazon.com/images/I/81JJPDNlxSL._AC_UF1000,1000_QL80_.jpg",
                SellerId = AdminSeller.Id,
                BuyerId = GuestUser.Id,
                IsApproved = true,
                IsAvailable = false
            };
            
        }
        private static void SeedAuthors()
        {
            FirstAuthor = new Author()
            {
                Id = 1,
                Name = "Alex Michaelides",
                Age = 45,
                Authobriography = "Has been writing psychology books for 20 years.Some of them are know araound the world"
            };
            
        }
        private static void SeedOrders()
        {
            FirstOrder = new Order()
            {
                BookId = FirstBook.Id,
                BuyerId = GuestUser.Id
            };
            
        }
    }
}


 

