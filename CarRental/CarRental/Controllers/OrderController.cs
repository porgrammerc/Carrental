using CarRental.Models;
using CarRental.Services.Interfaces;
using CarRental.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRental.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICarService _carService;
        private readonly UserManager<User> _userManager;
        public OrderController(IOrderService orderService, ICarService carService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _carService = carService;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> GetOrders(Guid id)
        {
            var orders = _orderService.GetUserOrders(id).ToList();
            var user = await _userManager.FindByIdAsync(id.ToString());

            var model = new OrderDataVM
            {
                UserId = id,
                Name = user.Name,
                LastName = user.LastName,
                Orders = orders,
                
            };

            return View(model);
        }

        public IActionResult Create(Guid id)
        {
            var car = _carService.GetCarBasicData(id);
            var model = new CreateOrderVM()
            {
                Car = car,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1)

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderVM order)
        {
            if(order.EndDate.Date < order.StartDate.Date)
            {
                ModelState.AddModelError("StartDate", "Data początkowa nie może być większa od daty końcowej.");
                return View(order);
            }
            var reservedDates = _orderService.GetReservedDates(order.Car.Id);
            foreach (var reservedDate in reservedDates)
            {
                if(order.StartDate.Date >= reservedDate.StartDate.Date && order.StartDate.Date <= reservedDate.EndDate.Date)
                {
                    ModelState.AddModelError("StartDate", "W tym dniu samochód jest zajęty.");
                    return View(order);
                }

                if(order.EndDate.Date >= reservedDate.StartDate.Date && order.EndDate.Date <= reservedDate.EndDate.Date)
                {
                    ModelState.AddModelError("EndDate", "W tym dniu samochód jest zajęty.");
                    return View(order);
                }
            }

            var currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _orderService.CreateOrder(order, currentUserId);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = $"{nameof(Role.Admin)}")]
        public IActionResult Delete(Guid id)
        {
            var userId = _orderService.DeleteOrder(id);
            return RedirectToAction("GetOrders", new { id = userId });
        }
    }
}
