using System.Drawing;

namespace Core.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public bool ContainsAlcohol { get; set; }
        public byte[] image { get; set; }
    }
}
