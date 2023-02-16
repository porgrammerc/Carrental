using CarRental.Models;
using CarRental.Repositories.Interfaces;
using CarRental.Services.Interfaces;
using CarRental.ViewModels.Car;

namespace CarRental.Services
{
    public class CarService : ICarService
    {
        public readonly ICarRepository _carRepository;
        public readonly IOrderService _orderService;
        public CarService(ICarRepository carRepository, IOrderService orderService)
        {
            _carRepository = carRepository;
            _orderService = orderService;
        }

        public void CreateCar(CarVM model)
        {
            var car = new Car
            {
                Brand = model.Brand,
                Color = model.Color,
                Model = model.Model,
                Photo = model.Photo,
                Price = model.Price
            };

            _carRepository.CreateCar(car);
        }

        public ViewCarVM GetCar(Guid id)
        {
            var car = _carRepository.GetCar(id);
            if(car != null)
            {
                var model = new ViewCarVM
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Color = car.Color,
                    Photo = car.Photo,
                    Price = car.Price,
                    Orders = _orderService.GetOrdersByCar(id)
                };

                return model;
            }

            return null;
        }

        public IEnumerable<CarVM> GetAllCars()
        {
            return _carRepository.GetAllCars().Select(x => new CarVM
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Photo = x.Photo,
                Price = x.Price,
                Color = x.Color,
            });
        }

        public void DeleteCar(Guid id)
        {
            _carRepository.DeleteCar(id);
        }

        public CarVM GetCarBasicData(Guid id)
        {
            var car = _carRepository.GetCar(id);
            var model = new CarVM
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Photo = car.Photo,
                Price = car.Price,
                Color = car.Color,
            };

            return model;
        }

        public void UpdateCar(CarVM model)
        {
            var car = _carRepository.GetCar(model.Id);
            car.Brand = model.Brand;
            car.Model = model.Model;
            car.Photo = model.Photo;
            car.Price = model.Price;
            car.Color = model.Color;

            _carRepository.UpdateCar(car);
        }
    }
}