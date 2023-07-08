using System.Text.Json.Serialization;

namespace Ass1Server.Models.OrderDetail
{
    public class OrderDetailUpdateDTO
    {
        [JsonPropertyName("OrderId")]
        public int OrderId { get; set; }
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("Discount")]
        public double Discount { get; set; }
    }
}
