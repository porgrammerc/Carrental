namespace CarRental.ViewModels.Order
{
    public class CreateOrderVM
    {
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}