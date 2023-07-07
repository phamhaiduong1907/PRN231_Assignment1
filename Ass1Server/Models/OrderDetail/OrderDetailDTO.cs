using System.Text.Json.Serialization;

namespace Ass1Server.Models.OrderDetail
{
    public class OrderDetailDTO
    {
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }
        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; }
        [JsonPropertyName("OrderId")]
        public int OrderId { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("Discount")]
        public double? Discount { get; set; }
        [JsonPropertyName("Price")]
        public double Price { get; set; }
    }
}
