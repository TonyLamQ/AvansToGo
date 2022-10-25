using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Canteen
    {
        public EnumCity? City { get; set; }
        [Key]
        public string? Location { get; set; }
        public bool? ServesHotMeals { get; set; }
    }
}
