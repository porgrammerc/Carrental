using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels.Order
{
    public class OrderDataVM
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<UserOrderVM> Orders { get; set; }        
    }
}