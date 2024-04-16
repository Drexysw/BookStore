using BookStore.Core.Contracts;
using BookStore.Core.Contracts.Admin;
using BookStore.Core.Models.Order;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Services
{
    public class OrderService : IOrderService
    {
        public readonly IRepository repository;
        public readonly IBookService bookService;
        public readonly IUserService userService;
        public OrderService(IRepository _repository,IBookService _bookService,IUserService _userService)
        {
            repository = _repository;
            bookService = _bookService;
            userService = _userService;
        }
        public async Task Create(int bookId, string userId)
        {
            Order order = new Order()
            {
                BookId = bookId,
                BuyerId = userId,
            };
            try
            {
                await repository.AddAsync(order);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task<IEnumerable<OrderServiceModel>> GetOrders()
        {
            return await repository.AllReadOnly<Order>()
                .Select(s => new OrderServiceModel()
                {
                    Buyer = userService.UserFullNameAsync(s.BuyerId).Result,
                    Book = bookService.GetBookNameByIdAsync(s.BookId)
                })
                .ToListAsync();
        }
    }
}
