using AutoFixture;
using CarRental.Models;
using CarRental.Repositories.Interfaces;
using CarRental.Services;
using CarRental.Services.Interfaces;
using CarRental.ViewModels.Car;
using Moq;

namespace Tests
{
    public class UnitTests
    {
        private Mock<ICarRepository> _carRepository;
        private Mock<IOrderRepository> _orderRepository;
        private Mock<OrderService> _orderService;
        private Fixture _fixture;
        public UnitTests()
        {
            _fixture = new Fixture();
            _orderRepository = new Mock<IOrderRepository>();
            _carRepository = new Mock<ICarRepository>();
            _orderService = new Mock<OrderService>(_orderRepository.Object);
        }

        [Fact]
        public void GetCarBasicData()
        {
            var car = _fixture.Build<Car>().Without(x => x.Orders).Create();
            _carRepository.Setup(x => x.GetCar(It.IsAny<Guid>())).Returns(car);
            ICarService carService = new CarService(_carRepository.Object, _orderService.Object);
            var viewCarVM = carService.GetCar(car.Id);
            Assert.Equal(car.Model, viewCarVM.Model);
            Assert.Equal(car.Color, viewCarVM.Color);
        }

        [Fact]
        public void CreateCar()
        {
            var carVM = _fixture.Create<CarVM>();
            ICarService carService = new CarService(_carRepository.Object, _orderService.Object);
            carService.CreateCar(carVM);
            _carRepository.Verify(x => x.CreateCar(It.IsAny<Car>()));
                
        }

        [Fact]
        public void DeleteOrder()
        {
            var orderId = _fixture.Create<Guid>();
            _orderService.Object.DeleteOrder(orderId);
            _orderRepository.Verify(x => x.DeleteOrder(It.IsAny<Guid>()));
        }

        [Fact]
        public void GetReservedDates()
        {
            var orders = _fixture.Build<Order>().Without(x => x.User).Without(x => x.Car).CreateMany(); ;
            _orderRepository.Setup(x => x.GetOrdersByCar(It.IsAny<Guid>())).Returns(orders);
            IOrderService orderService = new OrderService(_orderRepository.Object);
            var reservedDates = orderService.GetReservedDates(_fixture.Create<Guid>());
            Assert.NotNull(reservedDates);
        }
    }
}