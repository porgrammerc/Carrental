using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; } // cena za godzine
        public string Color { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}