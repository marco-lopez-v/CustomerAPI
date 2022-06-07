using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Customers.API.Models
{
    public class Customer
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Purshace>? Purshaces { get; set; }
    }
}