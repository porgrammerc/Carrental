using CarRental.ViewModels.Car;

namespace CarRental.Services.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarVM> GetAllCars();
        void CreateCar(CarVM model);
        ViewCarVM GetCar(Guid id);
        void DeleteCar(Guid id);
        CarVM GetCarBasicData(Guid id);
    }
}