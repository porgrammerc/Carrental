using CarRental.ViewModels.Order;

namespace CarRental.ViewModels.Car
{
    public class ViewCarVM: CarVM
    {
        public IEnumerable<OrderVM> Orders { get; set; }
    }
}