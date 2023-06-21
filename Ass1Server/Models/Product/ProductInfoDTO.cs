using System.Reflection;
using System.Text.Json.Serialization;

namespace Ass1Server.Models.Product
{
    public class ProductInfoDTO
    {
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }
        [JsonPropertyName("CategoryId")]
        public int CategoryId { get; set; }
        [JsonPropertyName("CategoryName")]
        public string CategoryName { get; set; }
        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; }
        [JsonPropertyName("Weight")]
        public double Weight { get; set; }
        [JsonPropertyName("UnitPrice")]
        public double UnitPrice { get; set; }
        [JsonPropertyName("UnitsInStock")]
        public int UnitsInStock { get; set; }
    }
}
