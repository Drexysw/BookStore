using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
