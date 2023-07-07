using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ass1Client.Model.Order
{
    class OrderWithDetailDTO
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
        //[JsonPropertyName("OrderDetails")]
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
        
    }
}
