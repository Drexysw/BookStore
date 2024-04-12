using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Become()
        {
            return View();
        }
    }
}
