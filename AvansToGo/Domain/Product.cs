using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Core.Domain
{
    public class Product
    {
        [Key]
        public string Name { get; set; } = null!;
        public bool ContainsAlcohol { get; set; }
        public string? ImageUrl { get; set; }
    }
}
