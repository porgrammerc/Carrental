using CarRental.Models;
using CarRental.Repositories.Interfaces;

namespace CarRental.Repositories
{
    public class CarRepository: ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void DeleteCar(Guid id)
        {
            var car = GetCar(id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCar(Guid id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }
    }
}