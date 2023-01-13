using Core.Domain;

namespace Portal.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public EnumCity? City { get; set; }
        public bool ContainsAlcohol { get; set; }
        public double? Price { get; set; } = null!;
        public Canteen? Canteen { get; set; }
        public string? CanteenLocation { get; set; }
        public List<string> Products { get; set; } = null!;
        public DateTime? PickUpTimeStart { get; set; }
        public DateTime? PickUpTimeEnd { get; set; }
        public EnumMealType Type;
        public Student? ReservedBy { get; set; }
        public int? StudentId { get; set; }

        public List<ProductCheckboxOptions>? Checkboxes { get; set; }


    }
}
