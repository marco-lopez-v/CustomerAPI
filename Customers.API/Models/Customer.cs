using System.ComponentModel.DataAnnotations;

namespace Customers.API.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
