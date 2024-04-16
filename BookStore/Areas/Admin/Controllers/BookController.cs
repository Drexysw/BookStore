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
        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            var book = await bookService.GetAnApprove();
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Approve(int houseId)
        {
            await bookService.ApproveBookAsync(houseId);
            return RedirectToAction(nameof(Approve));
        }
    }
}
