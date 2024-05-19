using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AboutController : BaseController
    {
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }
    }
}
