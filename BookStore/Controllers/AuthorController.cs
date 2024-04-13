using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
