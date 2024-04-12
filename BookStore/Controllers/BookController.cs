using BookStore.Core.Contracts;
using BookStore.Core.Models.Book;
using BookStore.Extensions.ClaimsPrincipalExtension;
using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> logger;
        private readonly ISellerService sellerService;
        private readonly IBookService bookService;
        public BookController(ILogger<BookController> _logger, IBookService _bookService, ISellerService _sellerService)
        {
            logger = _logger;
            bookService = _bookService;
            sellerService = _sellerService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllBooksQueryModel query)
        {
            if (User?.Identity?.IsAuthenticated == false)
            {
                return Unauthorized();
            }
            var result = await bookService.AllAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllBooksQueryModel.BooksPerPage);

            query.TotalBoardGamesCount = result.TotalBooksCount;
            query.Categories = await bookService.AllCategoriesNameAsync();
            query.Books = result.Books;

            return View(query);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (User?.Identity?.IsAuthenticated == false)
            {
                return Unauthorized();
            }
            if (id == 0)
            {
                return BadRequest();
            }
            if (await bookService.ExistByIdAsync(id) == false)
            {
                return RedirectToAction(nameof(All));
            }
            var model = await bookService.BookDetailsByIdAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookFormModel()
            {
                Categories = await bookService.AllCategoriesAsync(),
                Authors = await bookService.AuthorListAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            if (await sellerService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(SellerController.Become), "Seller");
            }
            if (await bookService.CategoryExist(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }
            if (ModelState.IsValid) 
            {
                model.Categories = await bookService.AllCategoriesAsync();
                model.Authors = await bookService.AuthorListAsync();
                return View(model);
            }
            int sellerId = await sellerService.GetSellerId(User.Id());
            int id = await bookService.CreateAsync(model, sellerId);
            return RedirectToAction(nameof(Details), new  { id = id});
        }
    }
}
