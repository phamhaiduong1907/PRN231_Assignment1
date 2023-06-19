using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ass1Server.Models.Product
{
    public class ProductModifyDTO
    {
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }
        [JsonPropertyName("CategoryId")]
        public int CategoryId { get; set; }
        [JsonPropertyName("ProductName")]
        [Required]
        public string ProductName { get; set; }
        [JsonPropertyName("Weight")]
        public double Weight { get; set; }
        [JsonPropertyName("UnitPrice")]
        public double UnitPrice { get; set; }
        [JsonPropertyName("UnitsInStock")]
        public int UnitsInStock { get; set; }
    }

}
