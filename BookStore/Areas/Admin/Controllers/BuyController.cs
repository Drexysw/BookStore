using BookStore.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class BuyController : AdminBaseController
    {
        private readonly IOrderService orderService;
        public BuyController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        public async Task<IActionResult> All()
        {
            var model = await  orderService.GetOrders();
            return View(model);
        }
    }
}
