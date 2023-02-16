using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarRental.ViewModels.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-.]).{8,}$", ErrorMessage = "Hasło musi zawierać cyfrę, dużą literę, znak specjalny i składać się co najmniej z 8 znaków")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potwierdzenie hasła jest wymagane")]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}