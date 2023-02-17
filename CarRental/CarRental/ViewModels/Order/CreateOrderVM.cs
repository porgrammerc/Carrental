using CarRental.ViewModels.Car;
using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels.Order
{
    public class CreateOrderVM
    {
        public CarVM Car { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Początek rezerwacji")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Koniec rezerwacji")]
        public DateTime EndDate { get; set; }
    }
}