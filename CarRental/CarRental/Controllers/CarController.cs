using CarRental.Services.Interfaces;
using CarRental.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarVM car)
        {
            _carService.CreateCar(car);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Get(Guid id)
        {
            var car = _carService.GetCar(id);
            return View(car);
        }

        public IActionResult Delete(Guid id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Update(Guid id)
        {
            var car = _carService.GetCarBasicData(id);
            return View(car);
        }
    }
}