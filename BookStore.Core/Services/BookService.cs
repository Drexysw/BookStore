using BookStore.Core.Contracts;
using BookStore.Core.Models.Book;
using BookStore.Core.Models.Category;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineBookstoreManagementSystem.Core.Models.Book;
using System.Linq;
namespace BookStore.Core.Services
{
    public class BookService : IBookService
    {
        private IRepository repository;
        private ILogger logger;

        public BookService(IRepository _repository, ILogger<BookService> _logger)
        {
            repository = _repository;
            this.logger = _logger;
        }

        public async Task<BookQueryServiceModel> AllAsync([FromQuery] string? category = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksperpage = 1)
        {
            var booksToShow = repository.AllReadOnly<Book>();
            var result = new BookQueryServiceModel();
            if (string.IsNullOrEmpty(category) == false)
            {
                booksToShow = booksToShow.Where(b => b.Category.Name == category);
            }
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                booksToShow = booksToShow.Where(b => b.Title.ToLower().Contains(normalizedSearchTerm) ||
                                                              b.Description.ToLower().Contains(normalizedSearchTerm));
            }
            booksToShow = sorting switch
            {
                BookSorting.Price => booksToShow.OrderBy(b => b.Price)
                                                .ThenBy(b => b.Title),
                BookSorting.NotBoughtFirst => booksToShow.OrderBy(b => b.BuyerId),
                _ => booksToShow.OrderBy(b => b.Id)
            };
            result.Books = await booksToShow
               .Skip((currentPage - 1) * booksperpage)
               .Take(booksperpage)
               .Select(b => new BooksAllServiceModel()
               {
                   Id = b.Id,
                   Title = b.Title,
                   ImageUrl = b.ImageUrl,
                   Price = b.Price,
                   IsAvailable = b.BuyerId != null,                                                                                         
               })
               .ToListAsync();
            result.TotalBooksCount = await booksToShow.CountAsync();
            return result;
        }

        public async Task<IEnumerable<BooksAllServiceModel>> AllBooksAsync()
        {
            return await repository.AllReadOnly<Book>()
                 .OrderBy(b => b.Id)
                 .Select(b => new BooksAllServiceModel()
                 {
                     Id = b.Id,
                     Title = b.Title,
                     ImageUrl = b.ImageUrl,
                     Price = decimal.Parse(b.Price.ToString("f2")),
                     IsAvailable = b.BuyerId != null
                 })
                 .ToListAsync();
        }

        public async Task<IEnumerable<BookCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .OrderBy(b => b.Name)
                .Select(b => new BookCategoryServiceModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNameAsync()
        {
            return await repository.AllReadOnly<Category>()
               .Select(c => c.Name)
               .Distinct()
               .ToListAsync();
        }

        public async Task<BookDetailsServiceModel> BookDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Book>()
                 .Where(b => b.Id == id)
                 .Select(b => new BookDetailsServiceModel()
                 {
                     Id = b.Id,
                     Title = b.Title,
                     ImageUrl = b.ImageUrl,
                     Description = b.Description,
                     Price = b.Price,
                     Category = b.Category.Name,
                     Author = b.Author.Name,
                     IsAvailable = b.BuyerId != null
                 })
                 .FirstAsync();
        }

        public async Task<int> CreateAsync(BookFormModel model, int sellerId)
        {
            var book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                SellerId = model.SellerId,
                Price = model.Price,
                CategoryId = model.CategoryId
            };
            try
            {
                await repository.AddAsync(book);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info", ex);
            }
            return book.Id;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            return await repository.AllReadOnly<Book>()
                .AnyAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BookServiceModel>> LastThreeBooksAsync()
        {
            return await repository.AllReadOnly<Book>()
                .OrderByDescending(b => b)
                .Take(3)
                 .Select(b => new BookServiceModel()
                 {
                     Id = b.Id,
                     Title = b.Title,
                     ImageUrl = b.ImageUrl,
                     IsAvailable = b.BuyerId != null
                 })
                 .ToListAsync();
        }
    }
}
