using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Package
    {
        [Key]
        public string Name { get; set; } = null!;
        public EnumCity City { get; set; }
        public bool ContainsAlcohol { get; set; }
        public double? Price { get; set; }
        public Canteen Canteen { get; set; } = null!;
        public string CanteenLocation { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
        public DateTime? PickUpTimeStart { get; set; }
        public DateTime? PickUpTimeEnd { get; set; }
        public EnumMealType Type;
        public Student? ReservedBy { get; set; }
        public int? StudentId { get; set; }
    }
}
