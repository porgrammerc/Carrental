using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "E-mail jest wymagany")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}