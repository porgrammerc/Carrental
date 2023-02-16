using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels.Car
{
    public class CarVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Marka auta jest wymagana")]
        [Display(Name = "Marka")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model auta jest wymagany")]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Display(Name = "Cena zł/h")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Kolor jest wymagany")]
        [Display(Name = "Kolor")]
        public string Color { get; set; }
        [Display(Name = "Link do zdjęcia")]
        public string Photo { get; set; }
    }
}