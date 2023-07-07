using System.Text.Json.Serialization;

namespace Ass1Server.Models.Order
{
    public class OrderReportDTO
    {
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("ShippedDate")]
        public DateTime? ShippedDate { get; set; }
        [JsonPropertyName("Freight")]
        public double? Freight { get; set; }
        [JsonPropertyName("Discount")]
        public double? Discount { get; set; } = 0;
        [JsonPropertyName("Price")]
        public double Price { get; set; }
    }
}
