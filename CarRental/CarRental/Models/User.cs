using Microsoft.AspNetCore.Identity;

namespace CarRental.Models
{
    public class User: IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public enum Role
    {
        User,
        Admin
    }
}