using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ass1Client.Model.Product
{
    public class ProductInfo
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
