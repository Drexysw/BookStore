using BookStore.Core.Contracts;
using BookStore.Core.Models.Author;
using BookStore.Core.Models.Book;
using BookStore.Core.Models.Category;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineBookstoreManagementSystem.Core.Models.Book;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
namespace BookStore.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repository;
        private readonly ILogger<BookService> logger;
        private readonly IAuthorService authorService;
        public BookService(IRepository _repository, ILogger<BookService> _logger, IAuthorService _authorService)
        {
            repository = _repository;
            logger = _logger;
            authorService = _authorService;
        }
        
        public async Task<BookQueryServiceModel> AllAsync([FromQuery] string? category = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksperpage = 1)
        {
            var booksToShow = repository.AllReadOnly<Book>()
                .Where(h => h.IsApproved);
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
                _ => booksToShow.OrderByDescending(b => b.Id)
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
                .Where(h => h.IsApproved)
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
                .Where(h => h.IsApproved)
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

        public async Task<bool> AuthorExist(string name)
        {
            return await repository.AllReadOnly<Author>()
                .AnyAsync(c => c.Name == name);
        }

        public async Task<int> CreateAsync(BookFormModel model, int sellerId)
        {
            var book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                SellerId = sellerId,
                Price = model.Price,
                CategoryId = model.CategoryId,
                AuthorId = authorService.GetAuthorIdByName(model.Author).Result,
                IsApproved = true,
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
                .Where(h => h.IsApproved)
                .AnyAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BookServiceModel>> LastThreeBooksAsync()
        {
            return await repository.AllReadOnly<Book>()
                .Where(h => h.IsApproved)
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

        public async  Task<bool> CategoryExist(int id)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<bool> IsBought(int id)
        {
            return (await repository.GetByIdAsync<Book>(id)).BuyerId != null;
        }

        public async Task<bool> IsBoughtByUserWithId(int houseId, string currentUserId)
        {
            bool result = false;
            var house = await repository.AllReadOnly<Book>()
                .Where(h => h.IsApproved)
                .Where(h => h.Id == houseId)
                .Where(h => h.IsAvailable)
                .FirstOrDefaultAsync();
            if (house != null && house.BuyerId == currentUserId)
            {
                result = true;
            }
            return result;
        }

        public async Task Buy(int houseId, string currentUserId)
        {
            var book = await repository.GetByIdAsync<Book>(houseId);
            if (book != null && book.BuyerId == null)
            {
                book.BuyerId = currentUserId;
                await repository.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("This book is already bought");
            }
        }

        public async Task<IEnumerable<BookDetailsServiceModel>> AllBooksByUserIdAsync(string userId)
        {
            return await repository.AllReadOnly<Book>()
                .Where(h => h.IsApproved)
                .Where(b => b.BuyerId == userId)
                .Where(b => b.IsAvailable)
                .Select(b => new BookDetailsServiceModel()
                { 
                    Id = b.Id,
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price,
                    Author = b.Author.Name,
                    Category = b.Category.Name,
                    Description = b.Description,
                    IsAvailable = b.BuyerId != null
                })
                .ToListAsync();


        }

        public async Task<IEnumerable<BookDetailsServiceModel>> AllBooksBySellerId(int sellerId)
        {
            return await repository.AllReadOnly<Book>()
                .Where(h => h.IsApproved)
               .Where(b => b.SellerId == sellerId)
               .Where(b => b.IsAvailable)
               .Select(b => new BookDetailsServiceModel()
               {
                   Id = b.Id,
                   Title = b.Title,
                   ImageUrl = b.ImageUrl,
                   Price = b.Price,
                   Author = b.Author.Name,
                   Category = b.Category.Name,
                   Description = b.Description,
                   IsAvailable = b.BuyerId != null
               })
               .ToListAsync();
        }

        public async Task Edit(int bookId, BookFormModel model)
        {
            var book = await repository.GetByIdAsync<Book>(bookId);

            book.Title = model.Title;
            book.ImageUrl = model.ImageUrl;
            book.Price = model.Price;
            book.CategoryId = model.CategoryId;
            book.Description = model.Description;
            book.AuthorId = authorService.GetAuthorIdByName(model.Author).Result;

            await repository.SaveChangesAsync();
        }

        public async Task<bool> HasSellerWithId(int bookId, string currentUserId)
        {
            bool result = false;
            var book = await repository.AllReadOnly<Book>()
                .Where(h => h.IsApproved)
                .Where(b => b.Id == bookId)
                .Where(h => h.IsAvailable)
                .Include(h => h.Seller)
                .FirstOrDefaultAsync();
            if (book?.Seller != null && book.Seller.UserId == currentUserId)
            {
                result =  true;
            }
            return result;
        }

        public async Task<int> GetBookCategoryId(int bookId)
        {
            return (await repository.GetByIdAsync<Book>(bookId)).CategoryId;
        }

        public async Task Delete(int bookId)
        {
            var book = await repository.GetByIdAsync<Book>(bookId);
             book.IsAvailable = false;
            await repository.DeleteAsync<Book>(bookId);
            await repository.SaveChangesAsync();
        }

        public async Task Leave(int bookId)
        {
            var book = await repository.GetByIdAsync<Book>(bookId);
            book.BuyerId = null;

            await repository.SaveChangesAsync();
        }

        public  string GetBookNameByIdAsync(int bookId)
        {
            return repository.GetByIdAsync<Book>(bookId).Result.Title;
        }
    }
}
