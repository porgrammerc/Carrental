using CarRental.ViewModels.Order;

namespace CarRental.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderVM> GetOrdersByCar(Guid id);
        void CreateOrder(CreateOrderVM model, Guid userId);
        IEnumerable<UserOrderVM> GetUserOrders(Guid id);
        IEnumerable<ReservedPeriod> GetReservedDates(Guid carId);
        Guid DeleteOrder(Guid id);
    }
}