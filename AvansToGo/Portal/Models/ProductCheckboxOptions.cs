using Core.Domain;

namespace Portal.Models
{
    public class ProductCheckboxOptions
    {
        public bool IsChecked { get; set; }

        public Product Value { get; set; } = null!;
    }
}
