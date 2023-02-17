using CarRental.Models;
using CarRental.Repositories.Interfaces;

namespace CarRental.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Guid DeleteOrder(Guid id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return order.UserId;
        }

        public IEnumerable<Order> GetOrdersByCar(Guid id)
        {
            return _context.Orders.Where(x => x.CarId == id);
        }

        public IEnumerable<Order> GetOrdersByUser(Guid id)
        {
            return _context.Orders.Where(x => x.UserId == id);
        }
    }
}