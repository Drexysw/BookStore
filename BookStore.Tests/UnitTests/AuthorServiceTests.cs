using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Common;
using BookStore.Core.Contracts;
using BookStore.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;
using BookStore.Infrastructure.Data.Models;

namespace BookStore.Tests.UnitTests
{
    
    
    public class AuthorServiceTests
    {
        private IRepository repository;
        private IAuthorService authorService;
        private ILogger<AuthorService> logger; 
        private ApplicationDbContext applicationDbContext;
        [OneTimeSetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ApplicationDbContext" + Guid.NewGuid().ToString())
                .Options;

            applicationDbContext = new ApplicationDbContext(dbContextOptions);

            applicationDbContext.Database.EnsureCreated();

            SeedDataBase.SeedDatabase(applicationDbContext);
        }
        public async Task TestAuthorByName()
        {
            var loggerMock = new Mock<ILogger<AuthorService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            var authorService = new AuthorService(repo);

            var authorName = await authorService.GetAuthorIdByName("Alex Michaelides");

            Assert.That(authorName, Is.EqualTo(1));
        }
        public async Task TestIfAuthorExist()
        {
            var loggerMock = new Mock<ILogger<AuthorService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            var authorService = new AuthorService(repo);

            var authorExist = await authorService.AuthorExist(1);

            if (authorExist)
            {
                Assert.IsTrue(authorExist);
            }
            else
            {
                Assert.IsFalse(authorExist);
            }
        }
        public async Task TestToCreateAuthor()
        {
            var loggerMock = new Mock<ILogger<AuthorService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            var authorService = new AuthorService(repo);

            await repo.AddAsync<Author>(new Author()
            {
                Id = 2,
                Name = "Test",
                Age = 1
            });
            await repo.SaveChangesAsync();
            var author = await repo.GetByIdAsync<Author>(2);
            Assert.That(author.Name, Is.EqualTo("Test"));
        }
        [OneTimeTearDown]
        public void TearDownBase()
        {
            applicationDbContext.Dispose();
        }
    }
}
