using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookStore.Core.Constants.RoleConstants;
namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    [AutoValidateAntiforgeryToken]
    public class AdminBaseController : Controller
    {
        
    }
}
