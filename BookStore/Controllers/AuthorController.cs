using BookStore.Core.Contracts;
using BookStore.Core.Models.Author;
using BookStore.Core.Services;
using BookStore.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : BaseController
    {
        private IAuthorService authorService;
        private IBookService bookService;
        public AuthorController(IAuthorService _authorService, IBookService bookService)
        {
            this.authorService = _authorService;
            this.bookService = bookService;

        }
        [HttpGet]
        public IActionResult Create()
        {
            var model =  new BookFormAuthorServiceModel();
            return  View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookFormAuthorServiceModel model)
        {
            if (model == null)
            {
                return View(model);
            }
            if (await bookService.AuthorExist(model.Name))
            {
                return RedirectToAction(nameof(BookController.All), "Book");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await authorService.CreateAsync(model);
            return RedirectToAction(nameof(BookController.All), "Book");
            }
    }
}
