using Newtonsoft.Json;

namespace Ordering
{
    public class Stroopwafel
    {
        [JsonProperty(PropertyName = "Type")]
        public StroopwafelType Type { get; set; }

        [JsonProperty(PropertyName = "Merk")]
        public Brand Brand { get; set; }

        [JsonProperty(PropertyName = "Prijs")]
        public decimal Price { get; set; }

        [JsonConstructor]
        public Stroopwafel(StroopwafelType type, Brand brand, decimal price)
        {
            this.Type = type;
            this.Brand = brand;
            this.Price = price;
        }

        public Stroopwafel(StroopwafelType type)
        {
            this.Type = type;
        }
    }
}
