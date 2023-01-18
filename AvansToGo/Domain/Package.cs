using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Package
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public EnumCity City { get; set; }
        public bool ContainsAlcohol { get; set; }
        public double? Price { get; set; } = null!;
        public Canteen? Canteen { get; set; }
        public string CanteenLocation { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
        public DateTime? PickUpTimeStart { get; set; }
        public DateTime? PickUpTimeEnd { get; set; }
        public EnumMealType Type { get; set; }
        public Student? ReservedBy { get; set; }
        public int? StudentId { get; set; }
    }
}
