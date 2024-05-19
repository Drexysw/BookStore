using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }

      
    }
}
