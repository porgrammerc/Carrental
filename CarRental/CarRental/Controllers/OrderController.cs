using CarRental.Services.Interfaces;
using CarRental.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRental.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Create(CreateOrderVM order)
        {
            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _orderService.CreateOrder(order, currentUserId);
            return View();
        }
    }
}
