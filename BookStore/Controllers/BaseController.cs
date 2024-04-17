using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class BaseController : Controller
    {
    }
}
