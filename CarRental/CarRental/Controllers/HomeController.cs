using CarRental.Models;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        public HomeController(ICarService carService)
        {
            _carService = carService;   
        }

        public IActionResult Index()
        {
            return View(_carService.GetAllCars());
        }
    }
}