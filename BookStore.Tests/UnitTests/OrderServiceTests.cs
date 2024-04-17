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
using Moq;
using BookStore.Infrastructure.Data.Models;

namespace BookStore.Tests.UnitTests
{
    public class OrderServiceTests
    {
        private IRepository repository;
        private ILogger<OrderService> logger;
        private IOrderService orderService;
        private IUserService userService;
        private ILogger<BookService> bookserviceLogger;
        private ApplicationDbContext bookDBContext;
        [OneTimeSetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ApplicationDbContext" + Guid.NewGuid().ToString())
                .Options;

            bookDBContext = new ApplicationDbContext(dbContextOptions);

            bookDBContext.Database.EnsureCreated();

            SeedDataBase.SeedDatabase(bookDBContext);
        }
        [OneTimeTearDown]
        public void TearDownBase()
        {
            bookDBContext.Dispose();
        }
    }
}
