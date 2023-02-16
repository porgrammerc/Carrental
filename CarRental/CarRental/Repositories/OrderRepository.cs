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
        public IEnumerable<Order> GetOrdersByCar(Guid id)
        {
            return _context.Orders.Where(x => x.CarId == id);
        }
    }
}
