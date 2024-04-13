using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infrastructure.Data.Configuration
{
    internal class SeedData
    {
        public ApplicationUser AdminUser { get; set; } = new ApplicationUser();
        public ApplicationUser GuestUser { get; set; } = new ApplicationUser();
        public ApplicationUser Admin2User { get; set; } = new ApplicationUser();
        public Seller Seller { get; set; } = new Seller();
        public Seller AdminSeller { get; set; } = new Seller();
        public Category NovelCategory { get; set; } = new Category();
        public Category PsychologyCategory { get; set; } = new Category();
        public Category ThrillerCategory { get; set; } = new Category();
        public Book FirstBook { get; set; } = new Book();
        public Book SecondBook { get; set; } = new Book();
        public Book ThirdBook { get; set; } = new Book();
        public Author FirstAuthor { get; set; } = new Author();
        public Author SecondAuthor { get; set; } = new Author();
        public Author ThirdAuthor { get; set; } = new Author();
        public SeedData()
        {
            SeedUsers();
            SeedSellers();
            SeedCategories();
            SeedAuthors();
            SeedBooks();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            AdminUser = new ApplicationUser()
            {
                Id = "deal1232-c23-dsds334-sdsk23-b2343431fefe",
                UserName = "seller@gmail.com",
                NormalizedUserName = "seller@gmail.com",
                Email = "seller@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                SecurityStamp = "2898835f-2cd7-4981-9394-5370ced1da30"
            };
            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");

            GuestUser = new ApplicationUser()
            {
                Id = "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224",
                UserName = "guestuser@gmail.com",
                NormalizedUserName = "guestuser@gmail.com",
                Email = "guestuser@gmail.com",
                NormalizedEmail = "guestuser@gmail.com"
            };
            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");

            Admin2User = new ApplicationUser()
            {
                Id = "bff69dcd-47cd-452a-8536-4823df1b2e70",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Stamo",
                LastName = "Petkov",
                SecurityStamp = "2e3112b8-6559-4e6f-a6ce-ee9595405798"
            };
            Admin2User.PasswordHash = hasher.HashPassword(Admin2User, "admin2123");
        }

        private void SeedSellers()
        {
            Seller = new Seller()
            {
                Id = 1,
                Name = "John",
                Rating = 5.5,
                UserId = AdminUser.Id,
            };
            AdminSeller = new Seller()
            {
                Id = 2,
                Name = "Stamo",
                Rating = 6,
                UserId = Admin2User.Id,
            };
        }

        private void SeedCategories()
        {
            ThrillerCategory = new Category()
            {
                Id = 1,
                Name = "Thriller"
            };
            PsychologyCategory = new Category()
            {
                Id = 2,
                Name = "Psychology"
            };
            NovelCategory = new Category()
            {
                Id = 3,
                Name = "Novel"
            };
        }

        private void SeedBooks()
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
                SellerId = Seller.Id,
                BuyerId = GuestUser.Id,
                IsAvailable = false
            };
            SecondBook = new Book()
            {
                Id = 2,
                Title = "The Psychology Of Money Book",
                Description = "How to manage your budget.Think of a money like a businessman.",
                CategoryId = PsychologyCategory.Id,
                AuthorId = SecondAuthor.Id,
                Price = 60.00m,
                ImageUrl = "https://5.imimg.com/data5/ANDROID/Default/2021/1/AD/UC/ZK/19351533/product-jpeg-1000x1000.jpeg",
                SellerId = Seller.Id,
                BuyerId = GuestUser.Id,
                IsAvailable = true
            };
            ThirdBook = new Book()
            {
                Id = 3,
                Title = "Fairy Tale",
                Description = "Join in a world full of fantasy and your mind will explode in happiness",
                CategoryId = NovelCategory.Id,
                AuthorId = ThirdAuthor.Id,
                Price = 70.00m,
                ImageUrl = "https://m.media-amazon.com/images/I/81blQfKsLtL._AC_UF1000,1000_QL80_.jpg",
                SellerId = Seller.Id,
                BuyerId = GuestUser.Id,
                IsAvailable = true
                
            };
        }
        private void SeedAuthors()
        {
            FirstAuthor = new Author()
            {
                Id = 1,
                Name = "Alex Michaelides",
                Age = 45,
                Authobriography = "Has been writing psychology books for 20 years.Some of them are know araound the world"
            };
            SecondAuthor = new Author()
            {
                Id = 2,
                Name = "Morgan Housel",
                Authobriography = "Keen on psychology since childhood Morgan Housel is one of the briliant people on earth who wrote araound 300 humdreds psychology books",
                Age = 30
            };
            ThirdAuthor = new Author()
            {
                Id = 3,
                Name = "Fairy Tale",
                Authobriography = "He is one of the most artistic people on earth",
                Age = 50
            };
        }
    }
}
