using CarRental.Models;
using CarRental.ViewModels.Car;

namespace CarRental.Repositories.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        void CreateCar(Car car);
        Car GetCar(Guid id);
        void DeleteCar(Guid id);
        void UpdateCar(Car car);
    }
}