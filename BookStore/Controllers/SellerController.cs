using BookStore.Core.Constants;
using BookStore.Core.Contracts;
using BookStore.Core.Models.Seller;
using BookStore.Extensions.ClaimsPrincipalExtension;
using BookStore.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
namespace BookStore.Controllers
{
    public class SellerController : BaseController
    {
        private readonly IRepository repository;
        private readonly ISellerService selllerService;
        public SellerController(IRepository _repository,ISellerService _sellerService)
        {
            repository = _repository;
            selllerService = _sellerService;
        }
        [HttpGet]
        public async  Task<IActionResult> Become()
        {
            if (await selllerService.ExistsById(User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "Вие вече сте Продавач";

                return RedirectToAction("Index", "Home");
            }
            var model = new BecomeSellerModel();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeSellerModel model)
        {
            var userId = User.Id();
            var name = User?.Identity?.Name;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await selllerService.ExistsById(userId))
            {
                TempData[MessageConstants.ErrorMessage] = "Вие вече сте Продавач";

                return RedirectToAction("Index", "Home");
            }
            if (await selllerService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstants.ErrorMessage] = "Телефона вече съществува";

                return RedirectToAction("Index", "Home");
            }
            if (await selllerService.UserHasBuys(userId))
            {
                TempData[MessageConstants.ErrorMessage] = "Не трябва да имате книги за да станете продавач";

                return RedirectToAction("Index", "Home");
            }
            await selllerService.Create(userId, model.PhoneNumber, name!);
            return RedirectToAction("All", "Book");
        }
    }
}
