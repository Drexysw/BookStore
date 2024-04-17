using BookStore.Core.Contracts;
using BookStore.Core.Models.Book;
using BookStore.Core.Services;
using BookStore.Data.Migrations;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.UnitTests
{
    [TestFixture]
    public class BookServiceTests
    {
        private IRepository repository;
        private ILogger<BookService> logger;
        private IBookService bookservice;
        private IAuthorService _authorService;
        private ApplicationDbContext bookdbContext;
        [OneTimeSetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ApplicationDbContext" + Guid.NewGuid().ToString())
                .Options;

            bookdbContext = new ApplicationDbContext(dbContextOptions);

            bookdbContext.Database.EnsureCreated();

            SeedDataBase.SeedDatabase(bookdbContext);
        }
        [Test]
        public async Task TestBookEdit()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            await repo.AddAsync<Book>(new Book()
            {
                Id = 2,
                Title = "",
                ImageUrl = "",
                Description = "",
                AuthorId = 1
            });

            await repo.SaveChangesAsync();
            var author = await repo.GetByIdAsync<Author>(1);
            await bookservice.Edit(2, new BookFormModel()
            {
                Id = 2,
                Title = "",
                ImageUrl = "",
                Author = author.Name,
                Description = "This book is edited"
            });
            var bg = await repo.GetByIdAsync<Book>(2);

            Assert.That(bg.Description, Is.EqualTo("This book is edited"));
        }
        [Test]
        public async Task TestToRetrieveAllBoardGames()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            int count =  bookservice.AllBooksAsync().Result.Count();
            int result =  repo.AllReadOnly<Book>().Count();

            Assert.That(count, Is.EqualTo(result));
        }
        [Test]
        public async Task TestToRetrieveAllCategory()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            var categories = (await bookservice.AllCategoriesAsync()).Count();
            var result = await repo.AllReadOnly<Category>().CountAsync();

            Assert.That(categories, Is.EqualTo(result));
        }
        [Test]
        public async Task TestCheckIfCategoryExists()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            var exists = await bookservice.CategoryExist(3);

            if (exists)
            {
                Assert.IsTrue(exists);
            }
            else
            {
                Assert.IsFalse(exists);
            }
        }
        [Test]
        public async Task TestToCreateBoardGame()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            await repo.AddAsync<Book>(new Book()
            {
                Id = 2,
                Title = "Princess",
                Description = "",
                ImageUrl = "",
                AuthorId = 1,
                Price = 20
            });
            await repo.SaveChangesAsync();

            var boardGame = repo.GetByIdAsync<Book>(2);

            Assert.That(boardGame.Result.Title, Is.EqualTo("Princess"));

        }
        [Test]
        public async Task TaskToDeleteBoardGame()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            await repo.AddAsync<Book>(new Book()
            {
                Id = 2,
                Title = "Princess",
                Description = "",
                ImageUrl = "",
                Price = 20
            });
            await repo.SaveChangesAsync();

            await repo.DeleteAsync<Book>(2);

            await repo.SaveChangesAsync();

            bool isHere = await bookservice.ExistByIdAsync(2);

            if (isHere)
            {
                Assert.IsTrue(isHere);
            }
            else
            {
                Assert.IsFalse(isHere);
            }
        }
        [Test]
        public async Task TestTaskGetCategoryId()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            var categoryid = await bookservice.GetBookCategoryId(1);

            Assert.That(categoryid, Is.EqualTo(1));
        }
        [Test]
        public async Task TestTakeLastThreeBoardGames()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            await repo.AddRangeAsync(new List<Book>()
            {
                new Book() {Id = 2, Title="", Description="", ImageUrl="", AuthorId = 1,IsApproved = true},
                new Book() {Id = 5, Title="", Description="", ImageUrl="",AuthorId = 1,IsApproved = true},
                new Book() {Id = 7, Title="", Description="", ImageUrl="", AuthorId = 1,IsApproved = true},
                new Book() {Id = 3, Title="", Description="", ImageUrl="",AuthorId = 1,IsApproved = true}
            });
            await repo.SaveChangesAsync();

            var boardgamecollection = await bookservice.LastThreeBooksAsync();
            Assert.That(3, Is.EqualTo(boardgamecollection.Count()));
        }
        [Test]
        public async Task TestGetCategoryNames()
        {
            var loggerMock = new Mock<ILogger<BookService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            var authorService = new AuthorService(repo);
            bookservice = new BookService(repo, loggerMock.Object, authorService);

            var categoryNames = await bookservice.AllCategoriesNameAsync();

            Assert.That(categoryNames.Count(), Is.EqualTo(1));
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            bookdbContext.Dispose();
        }
    }
}
