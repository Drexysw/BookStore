using BookStore.Core.Contracts;
using BookStore.Core.Models.Book;
using BookStore.Extensions.ClaimsPrincipalExtension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookStore.Core.Constants.RoleConstants;
namespace BookStore.Controllers
{
    public class BookController : BaseController
    {
        private readonly ILogger<BookController> logger;
        private readonly ISellerService sellerService;
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        public BookController(ILogger<BookController> _logger, IBookService _bookService, ISellerService _sellerService, IAuthorService _authorService)
        {
            logger = _logger;
            bookService = _bookService;
            sellerService = _sellerService;
            authorService = _authorService;
        }
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

            query.TotalBooksCount = result.TotalBooksCount;
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
            if ((await bookService.ExistByIdAsync(id)) == false)
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
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel model)
        {
            if (await sellerService.ExistsById(User.Id()) == false)
            {
                return RedirectToAction(nameof(SellerController.Become), "seller");
            }
            if (await bookService.CategoryExist(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }
            if (await bookService.AuthorExist(model.Author) == false)
            {
                return RedirectToAction(nameof(AuthorController.Create), "Author");
            }
            if (!ModelState.IsValid)
            {
                model.Categories = await bookService.AllCategoriesAsync();
                return View(model);
            }
            int sellerId = await sellerService.GetSellerId(User.Id());
            int id = await bookService.CreateAsync(model, sellerId);
            return RedirectToAction(nameof(Details), new { id = id });
        }
        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            if (await bookService.ExistByIdAsync(id) == false && User.IsAdmin() == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRole) && await sellerService.ExistsById(User.Id()))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await bookService.IsBought(id))
            {
                return RedirectToAction(nameof(All));
            }
            await bookService.Buy(id, User.Id());
            return RedirectToAction(nameof(Mine));
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {

            if (User.IsInRole(AdminRole))
            {
                return RedirectToAction("Mine", "Book", new { area = "Admin" });
            }

            IEnumerable<BookDetailsServiceModel> myBooks;
            var userId = User.Id();
            if (await sellerService.ExistsById(userId))
            {
                int sellerId = await sellerService.GetSellerId(userId);
                myBooks = await bookService.AllBooksBySellerId(sellerId);
            }
            else
            {
                myBooks = await bookService.AllBooksByUserIdAsync(userId);
            }
            return View(myBooks);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await bookService.ExistByIdAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }
            if (await bookService.HasSellerWithId(id, User.Id()) == false && User.IsAdmin() == false)
            {
                logger.LogInformation("User with id {0} attempted to open other seller book", User.Id());

                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
            var book = await bookService.BookDetailsByIdAsync(id);
            var categoryId = await bookService.GetBookCategoryId(id);
            var model = new BookFormModel()
            {
                Id = id,
                Title = book.Title,
                Description = book.Description,
                CategoryId = categoryId,
                ImageUrl = book.ImageUrl,
                Categories = await bookService.AllCategoriesAsync(),
                Author = book.Author,
                Price = book.Price,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookFormModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
            if (await bookService.ExistByIdAsync(id) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                model.Categories = await bookService.AllCategoriesAsync();

                return View(model);
            }
            if (await bookService.AuthorExist(model.Author) == false)
            {
                RedirectToAction(nameof(AuthorController.Create), "Author");
            }
            if ((await bookService.HasSellerWithId(model.Id, User.Id())) == false && User.IsAdmin() == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }
            if ((await bookService.CategoryExist(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.Categories = await bookService.AllCategoriesAsync();

                return View(model);
            }
            if (ModelState.IsValid == false)
            {
                model.Categories = await bookService.AllCategoriesAsync();

                return View(model);
            }
            await bookService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await bookService.ExistByIdAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await bookService.HasSellerWithId(id, User.Id())) == false && User.IsAdmin() == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var book = await bookService.BookDetailsByIdAsync(id);
            var model = new BookDetailsServiceModel()
            {
                ImageUrl = book.ImageUrl,
                Title = book.Title,
                Author = book.Author,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, BookDetailsServiceModel model)
        {
            if ((await bookService.ExistByIdAsync(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await bookService.HasSellerWithId(id, User.Id())) == false && User.IsAdmin() == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await bookService.Delete(id);

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if ((await bookService.ExistByIdAsync(id)) == false ||
                (await bookService.IsBought(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await bookService.IsBoughtByUserWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await bookService.Leave(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
