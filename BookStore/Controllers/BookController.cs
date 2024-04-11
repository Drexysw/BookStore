using BookStore.Core.Contracts;
using BookStore.Core.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> logger;
        private readonly IBookService bookService;
        public BookController(ILogger<BookController> _logger, IBookService _bookService)
        {
            logger = _logger;
            bookService = _bookService;
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
        public async Task<IActionResult> Create()
        {
            var model = new BookFormModel()
            {
                Categories = await bookService.AllCategoriesAsync(),
            };
            return View(model);
        }
    }
}
