using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ass1Client.Model.Order
{
    public class OrderUpdateDTO
    {
        [JsonPropertyName("OrderId")]
        public int OrderId { get; set; }
        [JsonPropertyName("ShippedDate")]
        public DateTime ShippedDate { get; set; }
        [JsonPropertyName("Freight")]
        public double Freight { get; set;}
    }
}
