using BookStore.Core.Contracts;
using BookStore.Extensions.ClaimsPrincipalExtension;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ISellerService sellerService;
        public OrderController(IOrderService _orderService,ISellerService _sellerService)
        {
            orderService = _orderService;
            sellerService = _sellerService;
        }
        public async Task<IActionResult> All()
        {
            if (!User.IsAdmin() || await sellerService.ExistsById(User.Id()) == false)
            {
                return Unauthorized();
            }
            var model = await orderService.GetOrders();
            return View(model);
        }
    }
}
