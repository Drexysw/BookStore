using BookStore.Core.Contracts;
using BookStore.Core.Services;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Contracts.Admin;
using BookStore.Core.Services.Admin;
using Moq;
using BookStore.Infrastructure.Data.Models;

namespace BookStore.Tests.UnitTests
{
    public class OrderServiceTests
    {
        private IRepository repository;
        private IOrderService orderService;
        private IUserService userService;
        private IAuthorService authorService;
        private ILogger<BookService> bookserviceLogger;
        private ApplicationDbContext bookdbContext;
        private IBookService bookService;
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
        public async Task TestIfTheOrderExist()
        {
            var loggerMockBookService = new Mock<ILogger<BookService>>();
            bookserviceLogger = loggerMockBookService.Object;
            repository = new Repository(bookdbContext); 
            userService = new UserService(repository);
            authorService = new AuthorService(repository);
            bookService = new BookService(repository, bookserviceLogger, authorService);
            orderService = new OrderService(repository, bookService, userService);


            var result = await orderService.Exist(1, "fbjfif33-c23-ooo21-sdsk23-a3jfjcj224");


            Assert.That(result, Is.True);
        }
        [OneTimeTearDown]
        public void TearDownBase()
        {
            bookdbContext.Dispose();
        }
    }
}
