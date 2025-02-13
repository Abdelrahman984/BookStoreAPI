using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Models
{
    public class Customer : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
