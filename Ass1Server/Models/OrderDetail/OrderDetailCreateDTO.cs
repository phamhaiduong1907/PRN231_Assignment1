using System.Text.Json.Serialization;

namespace Ass1Server.Models.OrderDetail
{
    public class OrderDetailCreateDTO
    {
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
    }
}
