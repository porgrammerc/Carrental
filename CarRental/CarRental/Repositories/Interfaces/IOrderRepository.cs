using CarRental.Models;

namespace CarRental.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersByCar(Guid id);
    }
}
