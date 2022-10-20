namespace Core.Domain
{
    public class Package
    {
        public string Name { get; set; }
        public EnumCity City { get; set; }
        public bool ContainsAlcohol { get; set; }
        public double price { get; set; }
        public Canteen Canteen { get; set; }
        public Student ReservedBy { get; set; }
        public List<Product> Products;
        public DateTime PickUpTimeStart { get; set; }
        public DateTime PickUpTimeEnd { get; set; }
        public EnumMealType type;
    }
}
