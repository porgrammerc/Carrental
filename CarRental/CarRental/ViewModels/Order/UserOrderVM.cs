using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels.Order
{
    public class UserOrderVM
    {
        public Guid OrderId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Display(Name = "Łączna kwota")]
        public double FullPrice { get; set; }
    }
}