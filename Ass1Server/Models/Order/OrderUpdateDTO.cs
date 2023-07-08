using System.Text.Json.Serialization;

namespace Ass1Server.Models.Order
{
    public class OrderUpdateDTO
    {
        [JsonPropertyName("OrderId")]
        public int OrderId { get; set; }
        [JsonPropertyName("ShippedDate")]
        public DateTime ShippedDate { get; set; }
        [JsonPropertyName("Freight")]
        public double Freight { get; set; }
    }
}
