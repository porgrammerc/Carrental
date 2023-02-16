using CarRental.Repositories.Interfaces;
using CarRental.Services.Interfaces;
using CarRental.ViewModels.Order;

namespace CarRental.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<OrderVM> GetOrdersByCar(Guid id)
        {
            var orders = _orderRepository.GetOrdersByCar(id);
            foreach(var order in orders)
            {
                yield return new OrderVM()
                {
                    Name = order.User.Name,
                    LastName = order.User.LastName,
                    StartDate = order.StartDate,
                    EndDate = order.EndDate
                };
            }
             
        }
    }
}
