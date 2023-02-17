using CarRental.Models;

namespace CarRental.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersByCar(Guid id);
        IEnumerable<Order> GetOrdersByUser(Guid id);
        void CreateOrder(Order order);
        Guid DeleteOrder(Guid id);
    }
}
