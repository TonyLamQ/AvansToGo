using Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Models
{
    public class PackageModel
    {
        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public EnumCity? City { get; set; }
        public bool ContainsAlcohol { get; set; }
        public double? Price { get; set; } = null!;
        public string? CanteenLocation { get; set; }
        public List<string>? Products { get; set; } = null!;
        public DateTime? PickUpTimeStart { get; set; }
        public DateTime? PickUpTimeEnd { get; set; }
        public EnumMealType Type { get; set; }



    }
}
