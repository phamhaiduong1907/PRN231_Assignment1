using Ass1Server.Models.OrderDetail;
using System.Text.Json.Serialization;

namespace Ass1Server.Models.Order
{
    public class OrderWithDetailDTO
    {
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("OrderId")]
        public int OrderId { get; set; }
        [JsonPropertyName("OrderDate")]
        public DateTime OrderDate { get; set; }
        [JsonPropertyName("RequiredDate")]
        public DateTime RequiredDate { get; set; }
        [JsonPropertyName("ShippedDate")]
        public DateTime? ShippedDate { get; set; }
        [JsonPropertyName("Freight")]
        public double? Freight { get; set; }
        [JsonPropertyName("OrderDetails")]
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
