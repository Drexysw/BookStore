using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Contracts;
using BookStore.Core.Services;
using BookStore.Infrastructure.Common;
using Microsoft.Extensions.Logging;
using Moq;
using BookStore.Infrastructure.Data.Models;

namespace BookStore.Tests.UnitTests
{
    public class SellerServiceTests
    {
        private IRepository repository;
        private ILogger<SellerService> logger;
        private ApplicationDbContext bookdbContext;
        private ISellerService sellerService;
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
        public async Task TestToCreateSeller()
        {
            var loggerMock = new Mock<ILogger<SellerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(bookdbContext);
            sellerService = new SellerService(repo);

            await repo.AddAsync<Seller>(new Seller()
            {
                Id = 3,
                UserId = "2141-fdfd",
                Name = "Test" 
            });
            await repo.SaveChangesAsync();

            var seller = await repo.GetByIdAsync<Seller>(3);
            Assert.That(3, Is.EqualTo(seller.Id));
        }

        [Test]
        public async Task TestExistById()
        {
            var repo = new Repository(bookdbContext);
            sellerService = new SellerService(repo);

            var exists = sellerService.ExistsById("bff69dcd-47cd-452a-8536-4823df1b2e70").Result;

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
        public async Task TestGetSellerId()
        {
            var repo = new Repository(bookdbContext);
            sellerService = new SellerService(repo);

            var result = await sellerService.GetSellerId("bff69dcd-47cd-452a-8536-4823df1b2e70");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task TestIfUserWithPhoneNumberExists()
        {
            var repo = new Repository(bookdbContext);
            sellerService = new SellerService(repo);

            var result = (await repo.GetByIdAsync<Seller>(2)).PhoneNumber;

            Assert.That(result, Is.EqualTo("+0875423556"));

        }

        [Test]
        public async Task TestUserHasBuysTask()
        {
            var repo = new Repository(bookdbContext);
            sellerService = new SellerService(repo);

            var result = await sellerService.UserHasBuys("fbjfif33-c23-ooo21-sdsk23-a3jfjcj224");

            Assert.That(true, Is.EqualTo(result));
        }

        [OneTimeTearDown]
        public void TearDownBase()
        {
            bookdbContext.Dispose();
        }
    }
}
