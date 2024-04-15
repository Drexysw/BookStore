using BookStore.Core.Contracts;
using BookStore.Core.Models.Book;
using BookStore.Core.Services;
using BookStore.Extensions.ClaimsPrincipalExtension;
using Microsoft.AspNetCore.Mvc;
namespace BookStore.Areas.Admin.Controllers
{
    public class BookController : AdminBaseController
    {
        private IBookService bookService;
        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<BookDetailsServiceModel> myBooks;
            var userId = User.Id();
            myBooks = await bookService.AllBooksByUserIdAsync(userId);
            return View(myBooks);

        }
    }
}
