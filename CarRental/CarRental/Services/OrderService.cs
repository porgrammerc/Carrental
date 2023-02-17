using CarRental.Models;
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

        public void CreateOrder(CreateOrderVM model, Guid userId)
        {
            var order = new Order
            {
                UserId = userId,
                CarId = model.Car.Id,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            _orderRepository.CreateOrder(order);
        }

        public IEnumerable<OrderVM> GetOrdersByCar(Guid id)
        {
            var orders = _orderRepository.GetOrdersByCar(id).ToList();
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

        public IEnumerable<ReservedPeriod> GetReservedDates(Guid carId)
        {
            var reservedDates = new List<ReservedPeriod>();
            var orders = _orderRepository.GetOrdersByCar(carId);
            foreach(var order in orders)
            {
                reservedDates.Add(new ReservedPeriod { StartDate = order.StartDate, EndDate = order.EndDate });
            }

            return reservedDates;
        }
        public IEnumerable<UserOrderVM> GetUserOrders(Guid id)
        {
            var orders = _orderRepository.GetOrdersByUser(id).ToList();
            return orders.Select(x => new UserOrderVM
            {
                OrderId = x.Id,
                Brand = x.Car.Brand,
                Model = x.Car.Model,
                Price = x.Car.Price,
                Photo = x.Car.Photo,
                Color = x.Car.Color,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                FullPrice = ((x.EndDate - x.StartDate).TotalDays + 1) * x.Car.Price
            });
        }

        public Guid DeleteOrder(Guid id)
        {
            return _orderRepository.DeleteOrder(id);
        }
    }
}
