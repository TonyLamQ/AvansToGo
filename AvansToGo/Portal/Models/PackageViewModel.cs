using Core.Domain;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        [Required(ErrorMessage ="BeginDate is missing")]
        public DateTime? PickUpTimeStart { get; set; }
        [Required(ErrorMessage = "EndDate is missing")]
        [FutureDate(ErrorMessage = "EndDate must be in the future")]
        public DateTime? PickUpTimeEnd { get; set; }
        public EnumMealType Type { get; set; }
        public Student? ReservedBy { get; set; }
        public int? StudentId { get; set; }

        public List<ProductCheckboxOptions>? Checkboxes { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime)value > DateTime.Now;
        }
    }
    public class BeforeFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime)value > DateTime.Now;
        }
    }
}
