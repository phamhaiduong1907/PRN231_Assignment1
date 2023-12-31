﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ass1Client.Model.Order
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
